using UnityEngine;

namespace Tsumu
{
    public class Tsumu : MonoBehaviour
    {
        private SpriteRenderer tsumu;

        private Animation anim;
       
        void Start()
        {
            tsumu = gameObject.GetComponent<SpriteRenderer>();
            anim = gameObject.GetComponent<Animation>();
        }

        public void Drag()
        {
            tsumu.color = Color.gray;
            anim.Play();
        }

        public void Cancel()
        {
            tsumu.color = Color.white;
        }
    }
}