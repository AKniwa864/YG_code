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
        private SpriteRenderer[] inFeverFrame;

        [SerializeField]
        private Timer timer;

        private GameManager gameManager;

        private ObjectPool linePool;

        private RectTransform backWidth;

        private RectTransform feverTrans;
        private Animation feverAnim;
        private Image fever;

        private float feverWidth;
        private float singleWidth;

        private int tsumuCount;
        public int TsumuCount
        {
            set
            {
                if (gameManager.IsFever)
                    return;

                tsumuCount = value;
                Add();
            }
            get { return tsumuCount; }
        }

        void Start()
        {
            gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
            linePool = inFever.GetComponent<ObjectPool>();
            backWidth = transform.parent.GetComponent<RectTransform>();
            feverTrans = GetComponent<RectTransform>();
            feverAnim = GetComponent<Animation>();
            fever = GetComponent<Image>();

            feverTrans.offsetMax = new Vector2(-backWidth.rect.width, feverTrans.offsetMax.y);

            feverWidth = backWidth.rect.width;
            singleWidth = backWidth.rect.width / Constants.FEVER_TSUMU_MIN;
        }

        void Update()
        {
            if (Constants.FEVER_TSUMU_MIN <= tsumuCount)
            {
                gameManager.IsFever = true;
                inFever.SetActive(true);

                foreach (SpriteRenderer obj in inFeverFrame)
                    obj.color = Color.gray;

                feverAnim.Play();

                for (int i = 0; i < Constants.EFFECT_LINE_AMOUNT; i++)
                    InvokeRepeating("PopLine", Random.Range(0.0f, 0.4f), Random.Range(0.2f, 0.6f));

                StartCoroutine(FeverTime());
            }
        }

        private void Add()
        {
            feverWidth = singleWidth * tsumuCount - backWidth.rect.width;

            if (feverWidth > 0)
                feverWidth = 0;

            UpdateBar();
        }

        private IEnumerator FeverTime()
        {
            float elapsedTime = 0.0f;
            tsumuCount = 0;

            while (elapsedTime < Constants.FEVER_TIME)
            {
                float rate = elapsedTime / Constants.FEVER_TIME;

                feverWidth = -backWidth.rect.width * rate;
                UpdateBar();

                elapsedTime += Time.deltaTime;

                yield return null;
            }

            feverWidth = -backWidth.rect.width;
            UpdateBar();
            gameManager.IsFever = false;
            inFever.SetActive(false);

            foreach (SpriteRenderer obj in inFeverFrame)
                obj.color = Color.white;

            feverAnim.Stop();
            fever.color = Constants.FEVER_COLOR_DEFAULT;
            
            CancelInvoke();
        }

        private void UpdateBar()
        {
            feverTrans.offsetMax = new Vector2(feverWidth, feverTrans.offsetMax.y);
        }

        private void PopLine()
        {
            linePool.PopObj(Vector2.zero);
        }
    }
}