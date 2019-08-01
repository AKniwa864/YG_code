using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private Text timerText;

        [SerializeField]
        private GameObject timeUp;

        private int timer = 60;
        private float countTime;

        private Coroutine tempCoroutine;

        void Start()
        {
            timer = 60;
            timerText.text = timer.ToString();

            tempCoroutine = StartCoroutine(limitTimer());

        }

        private IEnumerator limitTimer()
        {
            while (timer > 0)
            {
                yield return new WaitForSeconds(1.0f);
                timer--;
                timerText.text = timer.ToString();
            }

            timeUp.SetActive(true);
        }

        public void SwitchTimer(bool isActive)
        {
            if(isActive)
                tempCoroutine = StartCoroutine(limitTimer());
            else
                StopCoroutine(tempCoroutine);
        }
    }
}
