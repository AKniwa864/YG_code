using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneChanger : MonoBehaviour
    {
        private GameObject gameManager;

        void Start()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameController");
        }

        public void ToTitle()
        {
            StartCoroutine(Title());
        }

        public void ToGameMain()
        {
            StartCoroutine(GameMain());
        }

        private IEnumerator Title()
        {
            yield return new WaitForSecondsRealtime(Constants.BUTTON_ANIM_TIME);

            Destroy(gameManager);
            SceneManager.LoadScene("Title");
        }

        private IEnumerator GameMain()
        {
            yield return new WaitForSecondsRealtime(Constants.BUTTON_ANIM_TIME);

            SceneManager.LoadScene("GameMain");
        }
    }
}
