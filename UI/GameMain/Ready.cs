using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Ready : MonoBehaviour
    {
        [SerializeField]
        private Button pause;

        private Animator readyAnim;

        void Start()
        {
            readyAnim = gameObject.GetComponent<Animator>();
            pause.interactable = false;
        }

        void Update()
        {
            if (readyAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                gameObject.SetActive(false);
                pause.interactable = true;
            }
        }
    }
}