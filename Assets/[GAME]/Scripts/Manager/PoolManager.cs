using _GAME_.Scripts.Bears;
using _GAME_.Scripts.Extensions;
using UnityEngine;

namespace _GAME_.Scripts.Manager
{
    public class PoolManager : Manager<PoolManager>
    {
        #region SerializeField

        [Header("Prefabs")] [SerializeField] private ParticleBear dustParticlePrefab;
        [Header("Prefabs")] [SerializeField] private ParticleBear bloodParticlePrefab;
        [SerializeField] private Skeleton skeletonPrefab;
        [Header("Parents")] [SerializeField] private Transform dustParticleParent;
        [SerializeField] private Transform skeletonParent;
        [SerializeField] private Transform bloodParticleParent;

        #endregion

        #region Public Variables

        public CustomObjectPool<ParticleBear> dustParticlePool;
        public CustomObjectPool<Skeleton> skeletonPool;
        public CustomObjectPool<ParticleBear> bloodParticlePool;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            dustParticlePool =
                new CustomObjectPool<ParticleBear>(dustParticlePrefab, 10, dustParticleParent);

            skeletonPool = new CustomObjectPool<Skeleton>(skeletonPrefab, 10, skeletonParent);
            
            bloodParticlePool = new CustomObjectPool<ParticleBear>(bloodParticlePrefab, 10, bloodParticleParent);
        }

        #endregion
    }
}