using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SkillMeter : MonoBehaviour
    {
        [SerializeField]
        private Image mainTsumu;

        [SerializeField]
        private Animation skillReady;

        [SerializeField]
        private GameObject CutIn;

        [SerializeField]
        private GameObject skillButton;

        [SerializeField]
        private GameObject pause;

        [SerializeField]
        private Skill skill;

        [SerializeField]
        private Slider skillMeter;

        private GameManager gameManager;

        private int skillTsumuCount;
        public int SkillTsumuCount
        {
            set
            {
                skillTsumuCount = value;
                skillMeter.value = skillTsumuCount;
            }
            get { return skillTsumuCount; }
        }

        void Start()
        {
            gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
            mainTsumu.sprite = gameManager.MainTsumuSprite;
        }

        void Update()
        {
            if (skillTsumuCount >= skillMeter.maxValue && !skillButton.activeSelf)
            {
                skillButton.SetActive(true);
                skillReady.Play();
            }

            if (pause.activeSelf)
                skillButton.SetActive(false);
        }

        public void StartSkill()
        {
            CutIn.SetActive(true);
            skillButton.SetActive(false);

            skillReady.Stop();
            mainTsumu.transform.localScale = new Vector2(1.0f, 1.0f);

            skill.StartSkill();

            SkillTsumuCount = 0;
            Time.timeScale = 0.0f;
        }
    }
}