using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Combo : MonoBehaviour
    {
        [SerializeField]
        private Text comboValue;

        [SerializeField]
        private Animation comboAnim;

        [SerializeField]
        private Fever fever;
       
        private float duration;

        private int comboCount;
        public int ComboCount
        {
            set
            {
                comboCount = value;
                duration = 0;
                comboValue.text = comboCount.ToString();
                comboAnim.Play();
            }
            get { return comboCount; }
        }

        void Update()
        {
            if(duration >= Constants.COMBO_LIMIT_TIME && !fever.IsFever)
            {
                duration = 0;
                ComboCount = 0;
                gameObject.SetActive(false);
            }

            if(ComboCount > 0)
                duration += Time.deltaTime;
        }
    }
}
