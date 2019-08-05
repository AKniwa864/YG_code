using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField]
    private Tsumu.TsumuDrag tsumuDrag;

    [SerializeField]
    private ObjectPool bombPool;

    private List<GameObject> destroyTsumuList = new List<GameObject>();

    private GameManager gameManager;

    private GameObject skill;

    private string skillTag;

    private DestroyCollision skillCollision;

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
        Debug.Log(skillTag);
        switch(skillTag)
        { 
            case "AreaDestroy":
                skillCollision = skill.GetComponent<DestroyCollision>();
                break;
        }   
    }

    private void SwitchSkill()
    {
        switch (skillTag)
        {
            case "AreaDestroy":
                skill.SetActive(false);

                destroyTsumuList = skillCollision.DestroyTsumuList;

                if (destroyTsumuList.Count >= Constants.CONNECT_BOMB_MIN)
                    bombPool.PopObj(skillCollision.transform.localPosition);

                tsumuDrag.DestroyTsumu(destroyTsumuList);

                skill.SetActive(true);

                break;
        }
    }
}
