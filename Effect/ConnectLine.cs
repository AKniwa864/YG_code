using System.Collections.Generic;
using UnityEngine;

namespace Effect
{
    public class ConnectLine : MonoBehaviour
    {
        private ObjectPool connectLinePool;

        private List<GameObject> tsumuList = new List<GameObject>();

        private List<LineRenderer> lineList = new List<LineRenderer>();

        private List<Vector2> positionList = new List<Vector2>();

        void Start()
        {
            connectLinePool = gameObject.GetComponent<ObjectPool>();
        }

        void Update()
        {
            // ツムが動いた時の位置更新
            for(int i = 0; i < tsumuList.Count; i ++)
            {
                if ((positionList[i] - (Vector2)tsumuList[i].transform.position).magnitude < Constants.CONNECT_GAP_MIN)
                    continue;
                
                if (i == 0)
                {
                    if(lineList.Count != 0)
                        lineList[i].SetPosition(0, (Vector2)tsumuList[i].transform.position);

                    positionList[i] = tsumuList[i].transform.position;
                    continue;
                }
                else if(i == tsumuList.Count - 1)
                {
                    lineList[i - 1].SetPosition(1, (Vector2)tsumuList[i].transform.position);
                    positionList[i] = tsumuList[i].transform.position;
                    continue;
                }

                lineList[i - 1].SetPosition(1, (Vector2)tsumuList[i].transform.position);
                lineList[i].SetPosition(0, (Vector2)tsumuList[i].transform.position);
                positionList[i] = tsumuList[i].transform.position;
            }
        }

        public void Add(GameObject obj)
        {
            tsumuList.Add(obj);
            positionList.Add(obj.transform.position);

            if (positionList.Count < 2)
                return;

            lineList.Add(connectLinePool.PopConnectLine());

            lineList[lineList.Count - 1].SetPosition(0, positionList[positionList.Count - 2]);
            lineList[lineList.Count - 1].SetPosition(1, positionList[positionList.Count - 1]);
        }
        
        public void Clear()
        {
            foreach(LineRenderer renderer in lineList)
                connectLinePool.PushObj(renderer.gameObject);

            tsumuList = new List<GameObject>();
            lineList = new List<LineRenderer>();
            positionList = new List<Vector2>();
        }
    }
}
