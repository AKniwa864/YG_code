using UnityEngine;

namespace Effect
{
    public class ConnectValue : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] value = new Sprite[10];

        [SerializeField]
        private GameObject[] digit = new GameObject[Constants.CONNECT_DIGIT_MAX];

        [SerializeField]
        private Transform effect;

        private Animation anim;

        private SpriteRenderer[] digitRenderer = new SpriteRenderer[Constants.CONNECT_DIGIT_MAX];

        private int connect;
        public int Connect
        {
            set
            {
                connect = value;
                gameObject.SetActive(true);
            }
            private get { return connect; }
        }

        public Vector2 Pos
        {
            set { gameObject.transform.position = value; }
            private get { return gameObject.transform.position; }
        }

        void Awake()
        {
            for (int i = 0; i < Constants.CONNECT_DIGIT_MAX; i++)
                digitRenderer[i] = digit[i].GetComponent<SpriteRenderer>();

            anim = gameObject.GetComponent<Animation>();
        }

        void OnEnable()
        {
           SetDigit();
        }

        void Update()
        {
            if (!anim.isPlaying)
                gameObject.SetActive(false);
        }

        private void SetDigit()
        {
            int[] tempValue = new int[2];
            tempValue[0] = connect % 10;
            tempValue[1] = connect / 10;

            for (int i = 0; i < Constants.CONNECT_DIGIT_MAX; i++)
                digitRenderer[i].sprite = value[tempValue[i]];

            if (tempValue[1] == 0)
            {
                digit[1].SetActive(false);
                effect.localPosition = Vector3.zero;
            }
            else
            {
                digit[1].SetActive(true);
                transform.position += new Vector3(0.18f, 0.0f); ;
                effect.localPosition = new Vector3(-0.14f, 0.0f); ;
            }
        }
    }
}
