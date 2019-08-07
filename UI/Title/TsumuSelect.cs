using UnityEngine;
using UnityEngine.UI;
using System;

namespace UI
{
    public class TsumuSelect : MonoBehaviour
    {
        [SerializeField]
        private GameManager gameManager;

        [SerializeField]
        private Image[] characterSelect = new Image[3];

        [SerializeField]
        private Image tsumuSelect;

        [SerializeField]
        private Text nameEng;

        [SerializeField]
        private Text nameJap;

        [SerializeField]
        private Text skill;

        [SerializeField]
        private Sprite[] character = new Sprite[(int)Constants.Tsumu.Max];

        [SerializeField]
        private Sprite[] tsumu = new Sprite[(int)Constants.Tsumu.Max];

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
            }
            get { return currentTsumu; }
        }

        void Start()
        {
            currentTsumu = (int)Constants.Tsumu.Isabella;
            ChangeData();
            SetMainData();
        }

        private void ChangeData()
        {
            Constants.Tsumu tempCurrentTsumu;

            if (currentTsumu == 0)
            {
                characterSelect[0].sprite = character[(int)Constants.Tsumu.Max - 1];
                characterSelect[1].sprite = character[currentTsumu];
                characterSelect[2].sprite = character[currentTsumu + 1];
            }
            else if (currentTsumu == (int)Constants.Tsumu.Max - 1)
            {
                characterSelect[0].sprite = character[currentTsumu - 1];
                characterSelect[1].sprite = character[currentTsumu];
                characterSelect[2].sprite = character[0];
            }
            else
            {
                characterSelect[0].sprite = character[currentTsumu - 1];
                characterSelect[1].sprite = character[currentTsumu];
                characterSelect[2].sprite = character[currentTsumu + 1];
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
            gameManager.MainCharacterSprite = character[currentTsumu];
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