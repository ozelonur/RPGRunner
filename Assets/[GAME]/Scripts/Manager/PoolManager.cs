using _GAME_.Scripts.Bears;
using _GAME_.Scripts.Extensions;
using _ORANGEBEAR_.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Manager
{
    public class PoolManager : Bear
    {
        #region Singleton

        public static PoolManager Instance;

        #endregion

        #region SerializeField

        [Header("Prefabs")] [SerializeField] private ParticleBear dustParticlePrefab;
        [Header("Parents")] [SerializeField] private Transform dustParticleParent;

        #endregion

        #region Public Variables

        public CustomObjectPool<ParticleBear> dustParticlePool;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            dustParticlePool =
                new CustomObjectPool<ParticleBear>(dustParticlePrefab,10, dustParticleParent);
        }

        #endregion
    }
}