using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Fever : MonoBehaviour
    {
        [SerializeField]
        private GameObject inFever;

        [SerializeField]
        private Timer timer;

        private ObjectPool linePool;

        private RectTransform feverTrans;
        private Animation feverAnim;
        private Image fever;

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
            linePool = inFever.GetComponent<ObjectPool>();
            feverTrans = GetComponent<RectTransform>();
            feverAnim = GetComponent<Animation>();
            fever = GetComponent<Image>();

            feverWidth = feverTrans.sizeDelta.x;
            singleWidth = Constants.FEVER_WIDTH_MAX / Constants.FEVER_TSUMU_MIN;
        }

        void Update()
        {
            if (Constants.FEVER_TSUMU_MIN <= tsumuCount)
            {
                isFever = true;
                inFever.SetActive(true);

                feverAnim.Play();

                for (int i = 0; i < Constants.EFFECT_LINE_AMOUNT; i++)
                    InvokeRepeating("PopLine", Random.Range(0.0f, 0.4f), Random.Range(0.2f, 0.6f));

                timer.SwitchTimer(false);
                StartCoroutine(FeverTime());
            }
        }

        private void Add()
        {
            feverWidth = singleWidth * tsumuCount;

            if(feverWidth > Constants.FEVER_WIDTH_MAX)
                feverWidth = Constants.FEVER_WIDTH_MAX;

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

            feverAnim.Stop();
            fever.color = Color.white;
            
            timer.SwitchTimer(true);
            CancelInvoke();
        }

        private void UpdateBar()
        {
            feverTrans.sizeDelta = new Vector2(feverWidth, feverTrans.sizeDelta.y);
        }

        private void PopLine()
        {
            linePool.PopObj(Vector2.zero);
        }
    }
}