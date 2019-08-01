using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Result : MonoBehaviour
    {
        [SerializeField]
        private Score score;

        [SerializeField]
        private Text lastScore;

        [SerializeField]
        private Button Ranking;

        [SerializeField]
        private Button Retry;

        [SerializeField]
        private Button Title;

        [SerializeField]
        private float scoreUpdateTime;

        void Start()
        {
            StartCoroutine(LastScore());
            Title.interactable = false;
            Retry.interactable = false;
            Ranking.interactable = false;
        }
        
        private IEnumerator LastScore()
        {
            float elapsedTime = 0.0f;

            while (elapsedTime < scoreUpdateTime)
            {
                float rate = elapsedTime / scoreUpdateTime;

                lastScore.text = (score.ScoreValue * rate).ToString("N0");

                elapsedTime += Time.unscaledDeltaTime;

                yield return null;
            }

            lastScore.text = score.ScoreValue.ToString("N0");

            Title.interactable = true;
            Retry.interactable = true;
            Ranking.interactable = true;
        }

        public void ToRanking()
        {
            Time.timeScale = 1.0f;
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score.ScoreValue);
        }
    }
}
