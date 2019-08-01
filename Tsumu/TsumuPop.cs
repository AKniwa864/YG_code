using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tsumu
{
    public class TsumuPop : MonoBehaviour
    {
        [SerializeField]
        private int tsumuMax;

        private GameManager gameManager;

        public int TsumuCount { set; get; }

        void Start()
        {
            gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        }

        void Update()
        {
            if (tsumuMax > TsumuCount)
            {
                StartCoroutine(Pop(tsumuMax - TsumuCount));
                TsumuCount += tsumuMax - TsumuCount;
            }
        }

        private IEnumerator Pop(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Vector2 pos = new Vector2(Random.Range(-2.0f, 2.0f), 7.0f);
                GameObject obj = Instantiate(gameManager.Tsumu[Random.Range(0, gameManager.Tsumu.Length)], pos, Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward)) as GameObject;
                yield return new WaitForSeconds(0.08f);
            }
        }
    }
}
