using UnityEngine;

namespace Effect
{
    public class ChangeSkill : MonoBehaviour
    {
        private GameManager gameManager;

        private ObjectPool changeEffectPool;

        private SpriteRenderer tsumu;
        private Animation anim;

        void Start()
        {
            gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
            changeEffectPool = gameObject.GetComponentInParent<ObjectPool>();
            anim = gameObject.GetComponent<Animation>();
        }

        void Update()
        {
            if (gameManager.IsPause)
                return;

            anim["ChangeSkill"].time += Time.unscaledDeltaTime;

            if (anim.isPlaying)
                return;

            changeEffectPool.PushObj(gameObject);
            gameObject.SetActive(false);

            if(Time.timeScale == 0.0f)
                Time.timeScale = 1.0f;
        }
    }
}
