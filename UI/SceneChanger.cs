using System.Collections;
using System.Collections.Generic;
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
            Destroy(gameManager);
            SceneManager.LoadScene("Title");
        }

        public void ToGameMain()
        {
            SceneManager.LoadScene("GameMain");
        }
    }
}
