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

        private DestroyCollision bombCollision;

        public void OnClick(GameObject obj)
        {
            bombCollision = obj.GetComponentInChildren<DestroyCollision>();
            destroyTsumuList = bombCollision.DestroyTsumuList;

            objectPool.PushObj(obj);
            obj.SetActive(false);

            tsumuDrag.DestroyTsumu(destroyTsumuList);
        }
    }
}