using _GAME_.Scripts.Bears;
using _GAME_.Scripts.Extensions;
using UnityEngine;

namespace _GAME_.Scripts.Manager
{
    public class PoolManager : Manager<PoolManager>
    {
        #region SerializeField

        [Header("Prefabs")] [SerializeField] private ParticleBear dustParticlePrefab;
        [SerializeField] private Skeleton skeletonPrefab;
        [Header("Parents")] [SerializeField] private Transform dustParticleParent;
        [SerializeField] private Transform skeletonParent;

        #endregion

        #region Public Variables

        public CustomObjectPool<ParticleBear> dustParticlePool;
        public CustomObjectPool<Skeleton> skeletonPool;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            dustParticlePool =
                new CustomObjectPool<ParticleBear>(dustParticlePrefab, 10, dustParticleParent);

            skeletonPool = new CustomObjectPool<Skeleton>(skeletonPrefab, 10, skeletonParent);
        }

        #endregion
    }
}