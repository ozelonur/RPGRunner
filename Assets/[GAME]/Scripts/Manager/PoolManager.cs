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
        [Header("Prefabs")] [SerializeField] private MagicSphereBear magicSpherePrefab;
        [SerializeField] private Skeleton skeletonPrefab;
        [Header("Parents")] [SerializeField] private Transform dustParticleParent;
        [SerializeField] private Transform skeletonParent;
        [SerializeField] private Transform bloodParticleParent;

        #endregion

        #region Public Variables

        public CustomObjectPool<ParticleBear> dustParticlePool;
        public CustomObjectPool<Skeleton> skeletonPool;
        public CustomObjectPool<ParticleBear> bloodParticlePool;
        public CustomObjectPool<MagicSphereBear> magicParticlePool;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            dustParticlePool =
                new CustomObjectPool<ParticleBear>(dustParticlePrefab, 10, dustParticleParent);

            skeletonPool = new CustomObjectPool<Skeleton>(skeletonPrefab, 10, skeletonParent);
            
            bloodParticlePool = new CustomObjectPool<ParticleBear>(bloodParticlePrefab, 10, bloodParticleParent);
            
            magicParticlePool = new CustomObjectPool<MagicSphereBear>(magicSpherePrefab, 10, bloodParticleParent);
        }

        #endregion
    }
}