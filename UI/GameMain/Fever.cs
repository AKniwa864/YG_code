using System.Collections;
using UnityEngine;

namespace UI
{
    public class Fever : MonoBehaviour
    {
        [SerializeField]
        private GameObject inFever;

        [SerializeField]
        private Timer timer;

        [SerializeField]
        private RectTransform feverBar;

        [SerializeField]
        private int feverTsumuCount;

        private ObjectPool lineObjectPool;

        private bool isFever = false;
        public bool IsFever => isFever;

        private float feverWidth;
        private float singleWidth;

        private int tsumuCount;
        public int TsumuCount
        {
            set
            {
                if (isFever)
                    return;

                tsumuCount = value;
                Add();
            }
            get { return tsumuCount; }
        }

        void Start()
        {
            lineObjectPool = inFever.GetComponent<ObjectPool>();

            feverWidth = feverBar.sizeDelta.x;
            singleWidth = Constants.FEVER_WIDTH_MAX / feverTsumuCount;
        }

        void Update()
        {
            if (feverTsumuCount <= tsumuCount)
            {
                isFever = true;
                inFever.SetActive(true);

                for (int i = 0; i < Constants.EFFECT_LINE_AMOUNT; i++)
                    InvokeRepeating("PopLine", Random.Range(0.0f, 0.4f), Random.Range(0.2f, 0.6f));

                timer.SwitchTimer(false);
                StartCoroutine(FeverTime());
            }
        }

        private void Add()
        {
            feverWidth = singleWidth * tsumuCount;
            UpdateBar();
        }

        private IEnumerator FeverTime()
        {
            float elapsedTime = 0.0f;
            tsumuCount = 0;

            while (elapsedTime < Constants.FEVER_TIME)
            {
                float rate = elapsedTime / Constants.FEVER_TIME;

                feverWidth = Constants.FEVER_WIDTH_MAX * (1.0f - rate);
                UpdateBar();

                elapsedTime += Time.deltaTime;

                yield return null;
            }

            feverWidth = 0;
            UpdateBar();
            isFever = false;
            inFever.SetActive(false);
            timer.SwitchTimer(true);
            CancelInvoke();
        }

        private void UpdateBar()
        {
            feverBar.sizeDelta = new Vector2(feverWidth, feverBar.sizeDelta.y);
        }

        private void PopLine()
        {
            lineObjectPool.PopObj(Vector2.zero);
        }
    }
}