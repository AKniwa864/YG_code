using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField]
    private Tsumu.TsumuDrag tsumuDrag;

    [SerializeField]
    private ObjectPool bombPool;

    [SerializeField]
    private ObjectPool skillEffectPool;

    private List<GameObject> tsumuList = new List<GameObject>();

    private GameManager gameManager;

    private GameObject skill;

    private string skillTag;

    private CollisionList skillCollision;

    private Sprite mainTsumu;

    private Animation areaAnim;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

        skill = Instantiate(gameManager.Skill, Vector2.zero, Quaternion.identity);
        skill.transform.parent = transform;
        skillTag = skill.tag;
        
        SwitchStart();
    }

    public void StartSkill()
    {
        SwitchSkill();
    }

    private void SwitchStart()
    {
        switch(skillTag)
        { 
            case "AreaDestroy":
                skillCollision = skill.GetComponent<CollisionList>();
                areaAnim = skill.GetComponentInChildren<Animation>();
                break;
            case "AreaChange":
                skillCollision = skill.GetComponent<CollisionList>();
                mainTsumu = gameManager.MainTsumuSprite;
                break;
            case "RandomChange":
                mainTsumu = gameManager.MainTsumuSprite;
                break;
            case "PopBomb":
                break;
        }   
    }

    private void SwitchSkill()
    {
        switch (skillTag)
        {
            case "AreaDestroy":
                StartCoroutine("AreaDestroy");
                break;
            case "AreaChange":
                AreaChange();
                break;
            case "RandomChange":
                RandomChange(Constants.SKILL_CHANGE_AMOUNT);
                break;
            case "PopBomb":
                PopBomb(Constants.SKILL_BOMB_AMOUNT);
                break;
        }
    }

    private void AreaChange()
    {
        skill.SetActive(false);

        tsumuList = skillCollision.TsumuList;

        foreach (GameObject tempObj in tsumuList)
        {
            if (tempObj.name == (mainTsumu.name + "(Clone)"))
                continue;

            skillEffectPool.PopObj(tempObj.transform.position);

            tempObj.GetComponent<SpriteRenderer>().sprite = mainTsumu;
            tempObj.name = mainTsumu.name + "(Clone)";
        }
        skill.SetActive(true);
    }

    private void PopBomb(int amount)
    {
        while (amount > 0)
        {
            bombPool.PopObj(new Vector2(Random.Range(-2.0f, 2.0f), 3.0f));
            amount--;
        }
        Time.timeScale = 1.0f;
    }

    private void RandomChange(int amount)
    {
        GameObject tempObj;

        tsumuList.AddRange(GameObject.FindGameObjectsWithTag("Tsumu"));

        while (amount > 0)
        {
            tempObj = tsumuList[Random.Range(0, tsumuList.Count)];

            if (tempObj.name == (mainTsumu.name + "(Clone)"))
                continue;

            skillEffectPool.PopObj(tempObj.transform.position);

            tempObj.GetComponent<SpriteRenderer>().sprite = mainTsumu;
            tempObj.name = mainTsumu.name + "(Clone)";
            amount--;
        }
        tsumuList = new List<GameObject>();
    }

    private IEnumerator AreaDestroy()
    {
        areaAnim.Play();
        while (areaAnim.isPlaying)
        {
            if(!gameManager.IsPause)
                areaAnim[skill.name.Replace("(Clone)", "")].time += Time.unscaledDeltaTime;
            yield return null;
        }

        skill.SetActive(false);

        tsumuList = skillCollision.TsumuList;

        if (tsumuList.Count >= Constants.CONNECT_BOMB_MIN)
            bombPool.PopObj(skillCollision.transform.localPosition);

        tsumuDrag.DestroyTsumu(tsumuList);

        skill.SetActive(true);

        Time.timeScale = 1.0f;
    }
}
