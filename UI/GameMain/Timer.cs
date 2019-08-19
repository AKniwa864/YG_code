using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private GameObject timeUp;

        private GameManager gameManager;

        private Text timerText;

        private Image fill;

        private float timer;

        void Start()
        {
            gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

            timerText = gameObject.GetComponentInChildren<Text>();
            fill = gameObject.transform.Find("Fill").gameObject.GetComponent<Image>();

            timer = Constants.TIME_MAX;
            timerText.text = timer.ToString();
        }

        void Update()
        {
            if (gameManager.IsFever)
                return;

            timer -= Time.deltaTime;
            timerText.text = timer.ToString("#");

            fill.fillAmount -= 1.0f / Constants.TIME_MAX * Time.deltaTime;

            if (timer < 0)
            {
                timerText.text = "0";
                timeUp.SetActive(true);
            }
        }
    }
}
