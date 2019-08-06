using UnityEngine;

namespace Effect
{
    public class SkillEffect : MonoBehaviour
    {
        private ObjectPool skillEffectPool;

        private SpriteRenderer tsumu;
        private Animator anim;

        void Start()
        {
            skillEffectPool = gameObject.GetComponentInParent<ObjectPool>();
            anim = gameObject.GetComponent<Animator>();
        }

        void Update()
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
                return;

            skillEffectPool.PushObj(gameObject);
            gameObject.SetActive(false);

            if(Time.timeScale == 0.0f)
                Time.timeScale = 1.0f;
        }
    }
}
