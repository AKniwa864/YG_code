using UnityEngine;

namespace Effect
{
    public class Line : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer line;

        private ObjectPool objectPool;

        private float elapsedTime;


        void Start()
        {
            objectPool = gameObject.GetComponentInParent<ObjectPool>();
            line.positionCount = 2;
        }

        void OnEnable()
        {
            elapsedTime = 0.0f;
            Color tempColor;

            Vector3 tempPos = new Vector3(Random.Range(-5.0f, 5.0f), 7.0f, 0.0f);
            line.SetPosition(0, tempPos);

            tempPos = new Vector3(Random.Range(-5.0f, 5.0f), -7.0f, 0.0f);
            line.SetPosition(1, tempPos);

            tempColor = RandomColor(Random.Range(0, 2));
            line.SetColors(tempColor, tempColor);
        }

        void Update()
        {
            elapsedTime += Time.deltaTime;

            if(elapsedTime >= 0.2f)
            {
                objectPool.PushObj(gameObject);
            }
        }

        private Color32 RandomColor(int colorNo)
        {
            switch(colorNo)
            {
                case 0: return Constants.LINE_COLOR_CYAN;
                case 1: return Constants.LINE_COLOR_YELLOW;

                default: return Constants.LINE_COLOR_CYAN;
            }
        }
    }
}