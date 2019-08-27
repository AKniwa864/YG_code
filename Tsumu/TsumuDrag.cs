using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tsumu
{
    public class TsumuDrag : MonoBehaviour
    {
        [SerializeField]
        private GameObject cutIn;

        [SerializeField]
        private GameObject comboObj;

        [SerializeField]
        private TsumuPop tsumuPop;

        [SerializeField]
        private UI.Score score;

        [SerializeField]
        private UI.Fever fever;

        [SerializeField]
        private UI.SkillMeter skillMeter;

        [SerializeField]
        private ObjectPool effectPool;

        [SerializeField]
        private ObjectPool bombPool;

        [SerializeField]
        private Effect.ConnectLine connectLine;

        [SerializeField]
        private Effect.ConnectValue connectValue;

        [SerializeField]
        private Bomb bomb;

        private GameManager gameManager;

        private UI.Combo combo;

        private List<GameObject> dragTsumuList;

        private GameObject firstTsumu;
        private GameObject lastTsumu;

        private Vector2 valueEffectPos;
        public Vector2 ValueEffectPos
        {
            set { valueEffectPos = value; }
            private get { return valueEffectPos; }
        }

        private bool isConnect;
        public bool IsConnect
        {
            set { isConnect = value; }
            private get { return isConnect; }
        }

        void Start()
        {
            combo = comboObj.GetComponent<UI.Combo>();
            gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        }

        void Update()
        {
            if (gameManager.IsPause || cutIn.activeSelf)
                return;

            if (Input.GetMouseButtonDown(0) && firstTsumu == null)
            {
                OnDragStart();
            }
            else if (Input.GetMouseButtonUp(0) && firstTsumu != null)
            {
                OnDragEnd();
            }
            else if (firstTsumu != null)
            {
                OnDragging();
            }
        }

        private void OnDragStart()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider == null)
                return;

            GameObject hitObj = hit.collider.gameObject;

            if (hit.collider.tag == "Bomb")
            {
                bomb.OnClick(hitObj);
                return;
            }
            else if (hit.collider.tag != "Tsumu")
                return;


            isConnect = true;
            firstTsumu = lastTsumu = hitObj;
            dragTsumuList = new List<GameObject>();
            PushToList(hitObj);
        }

        private void OnDragging()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider == null)
                return;

            GameObject hitObj = hit.collider.gameObject;

            // 重複チェック
            foreach (GameObject obj in dragTsumuList)
            {
                if (hitObj == obj)
                    return;
            }

            if (hitObj.name == firstTsumu.name && hitObj != lastTsumu)
            {
                float distance = Vector2.Distance(hitObj.transform.position, lastTsumu.transform.position);

                if (distance < Constants.CONNECT_DISTANCE)
                {
                    lastTsumu = hitObj;
                    PushToList(hitObj);
                }
            }
        }

        private void OnDragEnd()
        {
            int tempCount = dragTsumuList.Count;

            if (tempCount >= Constants.CONNECT_MIN)
            {
                DestroyTsumu(dragTsumuList);

                if (tempCount >= Constants.CONNECT_BOMB_MIN)
                    bombPool.PopObj(dragTsumuList.Last().transform.position);
            }

            CancelDrag();
        }

        private void PushToList(GameObject obj)
        {
            dragTsumuList.Add(obj);
            obj.GetComponent<Tsumu>().Drag();
            connectLine.Add(obj);
        }

        public void DestroyTsumu(List<GameObject> list)
        {
            Constants.Tsumu tempMainTsumu = (Constants.Tsumu)Enum.ToObject(typeof(Constants.Tsumu), gameManager.MainTsumu);

            foreach (GameObject obj in list)
            {
                effectPool.PopObj(obj.transform.position);
                Destroy(obj);

                if (obj.name.Contains(tempMainTsumu.ToString()))
                    skillMeter.SkillTsumuCount++;

                fever.TsumuCount++;
            }

            if (!comboObj.activeSelf)
                comboObj.SetActive(true);
            combo.ComboCount++;

            score.Scoring(list.Count, combo.ComboCount);

            if (!isConnect)
                connectValue.Pos = valueEffectPos;
            else
                connectValue.Pos = list.Last().transform.position;
            connectValue.Connect = list.Count;
            tsumuPop.TsumuCount -= list.Count;
        }

        public void CancelDrag()
        {
            if (firstTsumu == null)
                return;

            foreach(GameObject obj in dragTsumuList)
                obj.GetComponent<Tsumu>().Cancel();

            dragTsumuList = new List<GameObject>();

            firstTsumu.GetComponent<Tsumu>().Cancel();
            lastTsumu.GetComponent<Tsumu>().Cancel();
            firstTsumu = null;
            lastTsumu = null;
            connectLine.Clear();
        }
    }
}