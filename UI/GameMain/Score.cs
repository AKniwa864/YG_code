using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField]
        private Text scoreText;

        private int scoreValue = 0;
        public int ScoreValue => scoreValue;

        void Start()
        {
            scoreValue = 0;
            scoreText.text = scoreValue.ToString();
        }

        public void Scoring(int dragCount, int comboCount)
        {
            int dragBonus = (dragCount - Constants.CONNECT_MIN) * (int)(0.2f * 100) + 100;
            float comboBonus = comboCount / 40.0f + 1.0f;
            int tempScore = (int)(dragBonus * comboBonus);

            scoreValue += tempScore;
            scoreText.text = scoreValue.ToString("N0");
        }
    }
}