using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField]
    private Tsumu.TsumuDrag tsumuDrag;

    [SerializeField]
    private ObjectPool bombPool;

    private List<GameObject> tsumuList = new List<GameObject>();

    private GameManager gameManager;

    private GameObject skill;

    private string skillTag;

    private CollisionList skillCollision;

    private Sprite mainTsumu;

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
                AreaDestroy();
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

    private void AreaDestroy()
    {
        skill.SetActive(false);

        tsumuList = skillCollision.TsumuList;

        if (tsumuList.Count >= Constants.CONNECT_BOMB_MIN)
            bombPool.PopObj(skillCollision.transform.localPosition);

        tsumuDrag.DestroyTsumu(tsumuList);

        skill.SetActive(true);
    }

    private void AreaChange()
    {
        skill.SetActive(false);

        tsumuList = skillCollision.TsumuList;

        foreach(GameObject obj in tsumuList)
        {
            if (obj.name == (mainTsumu.name + "(Clone)"))
                continue;

            obj.GetComponent<SpriteRenderer>().sprite = mainTsumu;
            obj.name = mainTsumu.name + "(Clone)";
        }

        skill.SetActive(true);
    }

    private void PopBomb(int amount)
    {
        while (amount > 0)
        {
            bombPool.PopObj(new Vector2(Random.Range(-2.0f, 2.0f), 6.0f));
            amount--;
        }
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

            tempObj.GetComponent<SpriteRenderer>().sprite = mainTsumu;
            tempObj.name = mainTsumu.name + "(Clone)";
            amount--;
        }
        tsumuList = new List<GameObject>();
    }
}
