using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System;

namespace UI
{
    public class TsumuSelect : MonoBehaviour
    {
        [SerializeField]
        private GameManager gameManager;

        [SerializeField]
        private GameObject birthDay;

        [SerializeField]
        private Image tsumuSelect;

        [SerializeField]
        private Text nameEng;

        [SerializeField]
        private Text nameJap;

        [SerializeField]
        private Text skill;

        [SerializeField]
        private GameObject[] character = new GameObject[(int)Constants.Tsumu.Max];

        [SerializeField]
        private Sprite[] tsumu = new Sprite[(int)Constants.Tsumu.Max];

        private Vector2[] characterPos = new Vector2[(int)Constants.Tsumu.Max];

        private SceneChanger sceneChenger;

        private Animator anim;

        private bool flick;
        public bool Flick
        {
            set
            {
                flick = value;

                if (flick)
                    StartCoroutine(Move());
            }
            get { return flick; }
        }

        private bool right;
        public bool Right
        {
            set { right = value; }
            private get { return right; }
        }

        private int currentTsumu;
        public int CurrentTsumu
        {
            set
            {
                if (value >= (int)Constants.Tsumu.Max)
                    currentTsumu = 0;
                else if (value < 0)
                    currentTsumu = (int)Constants.Tsumu.Max - 1;
                else
                    currentTsumu = value;

                ChangeData();
                SetMainData();
                flick = false;
            }
            get { return currentTsumu; }
        }

        void Start()
        {
            sceneChenger = gameObject.GetComponent<SceneChanger>();

            currentTsumu = (int)Constants.Tsumu.Isabella;

            anim = character[currentTsumu].GetComponent<Animator>();

            SavePos();
            ChangeData();
            SetMainData();
        }

        void Update()
        {
            if (anim == null)
                return;

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Pose" ))
            {
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                    sceneChenger.ToGameMain();
            }
        }

        private void ChangeData()
        {
            Constants.Tsumu tempCurrentTsumu;

            if (currentTsumu == (int)Constants.Tsumu.Isabella)
                birthDay.SetActive(true);
            else
                birthDay.SetActive(false);

            if (anim != character[currentTsumu].GetComponent<Animator>())
            {
                if (anim != null && anim.enabled)
                    anim.enabled = false;

                anim = character[currentTsumu].GetComponent<Animator>();

                if (character[currentTsumu].GetComponent<Animator>() != null && anim.enabled == false)
                    anim.enabled = true;
            }

            if (flick)
            {
                for (int i = 0; i < (int)Constants.Tsumu.Max; i ++)
                {
                    if (right)
                    {
                        if(i == (int)Constants.Tsumu.Max - 1)
                            character[(int)Constants.Tsumu.Max - 1].transform.position = characterPos[0];
                        else
                            character[i].transform.position = characterPos[i + 1];
                    }
                    else
                    {
                        if (i == 0)
                            character[i].transform.position = characterPos[(int)Constants.Tsumu.Max - 1];
                        else
                            character[i].transform.position = characterPos[i - 1];
                    }

                    if (i == currentTsumu)
                        character[i].GetComponent<SortingGroup>().sortingOrder = 2;
                    else
                        character[i].GetComponent<SortingGroup>().sortingOrder = 0;
                } 
            }
            tsumuSelect.sprite = tsumu[currentTsumu];

            tempCurrentTsumu = (Constants.Tsumu)Enum.ToObject(typeof(Constants.Tsumu), currentTsumu);
            nameEng.text = tempCurrentTsumu.ToString().ToUpper();
            nameJap.text = GetName((int)tempCurrentTsumu);
            SetSkillText(GetSkillType((int)tempCurrentTsumu));
        }

        private void SetMainData()
        {
            gameManager.MainTsumu = currentTsumu;
            gameManager.MainTsumuSprite = tsumu[currentTsumu];
            gameManager.MainCharacterName = character[currentTsumu].name;
        }

        private void SavePos()
        {
            for (int i = 0; i < (int)Constants.Tsumu.Max; i++)
                characterPos[i] = character[i].transform.position;
        }

        private IEnumerator Move()
        {
            float tempAmount = 0;

            SavePos();

            while (tempAmount < 3.5)
            {
                foreach (GameObject obj in character)
                {
                    if (right)
                        obj.transform.Translate(Constants.SELECT_FLICK_AMOUNT, 0, 0);
                    else
                        obj.transform.Translate(-Constants.SELECT_FLICK_AMOUNT, 0, 0);
                }

                tempAmount += Constants.SELECT_FLICK_AMOUNT;

                yield return null;
            }

            if (right)
                CurrentTsumu--;
            else
                CurrentTsumu++;
        }

        public void Pose()
        {
            if ((anim = character[currentTsumu].GetComponent<Animator>()) != null)
                anim.SetBool("Pose", true);
            else
                sceneChenger.ToGameMain();
        }

        private string GetName(int tsumuNo)
        {
            switch (tsumuNo)
            {
                case 0:
                    return Constants.Name.LEO;
                case 1:
                    return Constants.Name.YUKARI;
                case 2:
                    return Constants.Name.RANPHA;
                case 3:
                    return Constants.Name.MARIA;
                case 4:
                    return Constants.Name.JENNIFER;
                case 5:
                    return Constants.Name.RAKSHATA;
                case 6:
                    return Constants.Name.REBECCA;
                case 7:
                    return Constants.Name.EMMA;
                case 8:
                    return Constants.Name.ISABELLA;
                default:
                    return null;
            }
        }

        private Constants.SkillType GetSkillType(int tsumuNo)
        {
            switch (tsumuNo)
            {
                case 0:
                    return Constants.SkillType.HorizontalDestroy;
                case 1:
                    return Constants.SkillType.PopBomb;
                case 2:
                    return Constants.SkillType.CenterChange;
                case 3:
                    return Constants.SkillType.HorizontalDestroy;
                case 4:
                    return Constants.SkillType.VerticalDestroy;
                case 5:
                    return Constants.SkillType.PopBomb;
                case 6:
                    return Constants.SkillType.VerticalDestroy;
                case 7:
                    return Constants.SkillType.CenterChange;
                case 8:
                    return Constants.SkillType.RandomChange;
                default:
                    return Constants.SkillType.VerticalDestroy;
            }
        }

        private void SetSkillText(Constants.SkillType skillType)
        {
            switch (skillType)
            {
                case Constants.SkillType.VerticalDestroy:
                    skill.text = "縦ライン状にパズルを消すよ！";
                    break;
                case Constants.SkillType.HorizontalDestroy:
                    skill.text = "横ライン状にパズルを消すよ！";
                    break;
                case Constants.SkillType.CenterChange:
                    skill.text = "中央のパズルを" + GetName(currentTsumu) + "に変えるよ！";
                    break;
                case Constants.SkillType.RandomChange:
                    skill.text = "パズルを" + Constants.SKILL_CHANGE_AMOUNT + "個" + GetName(currentTsumu) + "に変えるよ！";
                    break;
                case Constants.SkillType.PopBomb:
                    skill.text = "ボムを" + Constants.SKILL_BOMB_AMOUNT + "個発生させるよ！";
                    break;
                default:
                    skill.text = "該当なし";
                    break;
            }
        }
    }
}