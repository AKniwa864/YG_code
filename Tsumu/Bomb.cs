using System.Collections.Generic;
using UnityEngine;

namespace Tsumu
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField]
        private ObjectPool objectPool;

        [SerializeField]
        private TsumuDrag tsumuDrag;

        private List<GameObject> destroyTsumuList = new List<GameObject>();

        private CollisionList bombCollision;

        public void OnClick(GameObject obj)
        {
            bombCollision = obj.GetComponentInChildren<CollisionList>();
            destroyTsumuList = bombCollision.TsumuList;

            objectPool.PushObj(obj);
            obj.SetActive(false);

            tsumuDrag.DestroyTsumu(destroyTsumuList);
        }
    }
}