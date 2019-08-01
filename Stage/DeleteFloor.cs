using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tsumu;

namespace Stage
{
    public class DeleteFloor : MonoBehaviour
    {
        [SerializeField]
        TsumuPop tsumuPop;

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Tsumu")
            {
                Destroy(collision.gameObject);
                tsumuPop.TsumuCount--;
            }
        }
    }
}