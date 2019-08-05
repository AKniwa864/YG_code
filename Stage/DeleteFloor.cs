using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tsumu;

namespace Stage
{
    public class DeleteFloor : MonoBehaviour
    {
        [SerializeField]
        ObjectPool bombPool;

        [SerializeField]
        TsumuPop tsumuPop;

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Tsumu")
            {
                Destroy(collision.gameObject);
                tsumuPop.TsumuCount--;
            }

            if (collision.gameObject.tag == "Bomb")
            {
                Destroy(collision.gameObject);
                bombPool.PopObj(new Vector2(Random.Range(-2.0f, 2.0f), 6.0f));

            }
        }
    }
}