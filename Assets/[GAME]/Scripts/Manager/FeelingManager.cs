using _GAME_.Scripts.Bears;
using _GAME_.Scripts.Extensions;
using UnityEngine;

namespace _GAME_.Scripts.Manager
{
    public class FeelingManager : Manager<FeelingManager>
    {
        #region Public Methods

        public void PlayDustParticle(Transform parent, Vector3 position)
        {
            ParticleBear dust = PoolManager.Instance.dustParticlePool.Get();
            dust.Play(parent, position);
        }

        #endregion
    }
}