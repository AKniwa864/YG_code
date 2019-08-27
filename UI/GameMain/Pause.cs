using UnityEngine;

namespace UI
{
    public class Pause : MonoBehaviour
    {
        private GameManager gameManager;

        void Awake()
        {
            gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        }

        void OnEnable()
        {
            Time.timeScale = 0.0f;
            gameManager.IsPause = true;
        }

        void OnDisable()
        {
            Time.timeScale = 1.0f;
            gameManager.IsPause = false;
        }
    }
}
