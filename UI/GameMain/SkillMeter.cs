﻿using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SkillMeter : MonoBehaviour
    {
        [SerializeField]
        private Image mainTsumu;

        [SerializeField]
        private GameObject cutIn;

        [SerializeField]
        private GameObject skillButton;

        [SerializeField]
        private Skill skill;

        private GameManager gameManager;

        private Animator cutInAnim;

        private Animation skillReady;

        private Slider skillMeter;

        private Button button;

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
            cutInAnim = cutIn.GetComponent<Animator>();
            skillReady = gameObject.GetComponentInParent<Animation>();
            skillMeter = gameObject.GetComponent<Slider>();
            button = skillButton.GetComponent<Button>();

            mainTsumu.sprite = gameManager.MainTsumuSprite;
        }

        void Update()
        {
            if (cutIn.activeSelf)
            {
                if (cutInAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
                    return;

                skill.StartSkill();

                cutIn.SetActive(false);
            }

            if (skillTsumuCount >= skillMeter.maxValue && !skillButton.activeSelf)
            {
                skillButton.SetActive(true);
                skillReady.Play();
            }

            if (gameManager.IsPause)
                button.enabled = false;
            else if(!button.enabled)
                button.enabled = true;
        }

        public void StartCutIn()
        {
            cutIn.SetActive(true);
            skillButton.SetActive(false);

            skillReady.Stop();
            mainTsumu.transform.localScale = new Vector2(1.0f, 1.0f);

            SkillTsumuCount = 0;
            Time.timeScale = 0.0f;
        }
    }
}