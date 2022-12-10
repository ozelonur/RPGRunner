using _GAME_.Scripts.Bears;
using _GAME_.Scripts.Extensions;
using UnityEngine;

namespace _GAME_.Scripts.Manager
{
    public class PoolManager : Manager<PoolManager>
    {

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
            dustParticlePool =
                new CustomObjectPool<ParticleBear>(dustParticlePrefab,10, dustParticleParent);
        }

        #endregion
    }
}