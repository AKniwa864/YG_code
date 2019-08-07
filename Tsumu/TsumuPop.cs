using System.Collections;
using UnityEngine;

namespace Tsumu
{
    public class TsumuPop : MonoBehaviour
    {
        private GameManager gameManager;

        public int TsumuCount { set; get; }

        void Start()
        {
            gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        }

        void Update()
        {
            if (Constants.TSUMU_MAX > TsumuCount)
            {
                StartCoroutine(Pop(Constants.TSUMU_MAX - TsumuCount));
                TsumuCount += Constants.TSUMU_MAX - TsumuCount;
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
