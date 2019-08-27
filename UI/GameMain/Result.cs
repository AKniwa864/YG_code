using System.Collections;
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
        private Button[] button = new Button[3];

        [SerializeField]
        private Button pause;

        void OnEnable()
        {
            StartCoroutine(LastScore());

            foreach (Button btn in button)
                btn.interactable = false;
        }
        
        private IEnumerator LastScore()
        {
            float elapsedTime = 0.0f;

            pause.interactable = false;

            while (elapsedTime < Constants.SCORE_UPDATE_TIME)
            {
                float rate = elapsedTime / Constants.SCORE_UPDATE_TIME;

                lastScore.text = (score.ScoreValue * rate).ToString("N0");

                elapsedTime += Time.unscaledDeltaTime;

                yield return null;
            }

            lastScore.text = score.ScoreValue.ToString("N0");

            foreach (Button btn in button)
                btn.interactable = true;
        }

        public void ToRanking()
        {
            StartCoroutine(Ranking());
        }

        private IEnumerator Ranking()
        {
            yield return new WaitForSecondsRealtime(Constants.BUTTON_ANIM_TIME);

            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score.ScoreValue);
        }
    }
}
