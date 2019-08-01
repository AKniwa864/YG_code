using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class Ready : MonoBehaviour
    {
        [SerializeField]
        private GameObject ready;

        [SerializeField]
        Tsumu.TsumuPop tsumuPop;

        private Animator readyAnim;

        void Start()
        {
            readyAnim = ready.GetComponent<Animator>();
        }

        void Update()
        {
            if (readyAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                ready.SetActive(false);
        }
    }
}