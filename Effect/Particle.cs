using UnityEngine;

namespace Effect
{
    public class Particle : MonoBehaviour
    {
        private ObjectPool objectPool;

        void Start()
        {
            objectPool = gameObject.GetComponentInParent<ObjectPool>();
        }

        private void OnParticleSystemStopped()
        {
            objectPool.PushObj(gameObject);
            gameObject.SetActive(false);
        }
    }
}
