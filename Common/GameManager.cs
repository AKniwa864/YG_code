using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int mainTsumu;
    public int MainTsumu
    {
        set { mainTsumu = value; }
        get { return mainTsumu; }
    }

    private Sprite mainTsumuSprite;
    public Sprite MainTsumuSprite
    {
        set { mainTsumuSprite = value; }
        get { return mainTsumuSprite; }
    }

    private Sprite mainCharacterSprite;
    public Sprite MainCharacterSprite
    {
        set { mainCharacterSprite = value; }
        get { return mainCharacterSprite; }
    }

    private bool isPause;
    public bool IsPause
    {
        set { isPause = value; }
        get { return isPause; }
    }

    private GameObject skill;
    public GameObject Skill => skill;

    private GameObject[] tsumu = new GameObject[4];
    public GameObject[] Tsumu => tsumu;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void OnGameStart()
    {
        List<int> numbersList = new List<int>();
        int count = 1;

        tsumu[0] = LoadTsumu(mainTsumu);
        skill = LoadSkill(mainTsumu);

        for (int i = 0; i < (int)Constants.Tsumu.Max; i++)
        {
            if (i == mainTsumu)
                continue;

            numbersList.Add(i);
        }

        // 重複不可のランダム
        while (count < tsumu.Length)
        {
            int index = Random.Range(0, numbersList.Count);
            int randomNo = numbersList[index];

            tsumu[count] = LoadTsumu(randomNo);

            numbersList.RemoveAt(index);
            count++;
        }
    }

    private GameObject LoadTsumu(int randamNo)
    {
        switch (randamNo)
        {
            case 0:
                return (GameObject)Resources.Load(Constants.Data.LEO);
            case 1:
                return (GameObject)Resources.Load(Constants.Data.YUKARI);
            case 2:
                return (GameObject)Resources.Load(Constants.Data.RANPHA);
            case 3:
                return (GameObject)Resources.Load(Constants.Data.MARIA);
            case 4:
                return (GameObject)Resources.Load(Constants.Data.JENNIFER);
            case 5:
                return (GameObject)Resources.Load(Constants.Data.RAKSHATA);
            case 6:
                return (GameObject)Resources.Load(Constants.Data.REBECCA);
            case 7:
                return (GameObject)Resources.Load(Constants.Data.EMMA);
            case 8:
                return (GameObject)Resources.Load(Constants.Data.ISABELLA);
            default:
                return null;
        }
    }

    private GameObject LoadSkill(int mainTsumu)
    {
        switch (mainTsumu)
        {
            case 0:
                return (GameObject)Resources.Load(Constants.Data.HORIZONTAL_DESTROY);
            case 1:
                return (GameObject)Resources.Load(Constants.Data.POP_BOMB);
            case 2:
                return (GameObject)Resources.Load(Constants.Data.CENTER_CHANGE);
            case 3:
                return (GameObject)Resources.Load(Constants.Data.HORIZONTAL_DESTROY);
            case 4:
                return (GameObject)Resources.Load(Constants.Data.VERTICAL_DESTROY);
            case 5:
                return (GameObject)Resources.Load(Constants.Data.POP_BOMB);
            case 6:
                return (GameObject)Resources.Load(Constants.Data.VERTICAL_DESTROY);
            case 7:
                return (GameObject)Resources.Load(Constants.Data.CENTER_CHANGE);
            case 8:
                return (GameObject)Resources.Load(Constants.Data.RANDOM_CHANGE);
            default:
                return (GameObject)Resources.Load(Constants.Data.VERTICAL_DESTROY);
        }
    }
}
