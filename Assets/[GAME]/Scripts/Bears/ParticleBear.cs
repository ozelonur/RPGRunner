using _GAME_.Scripts.Manager;
using _ORANGEBEAR_.EventSystem;
using DG.Tweening;
using UnityEngine;

namespace _GAME_.Scripts.Bears
{
    public class ParticleBear : Bear
    {
        #region Private Variables

        private ParticleSystem _particleSystem;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        #endregion

        #region Public Methods

        public void Play(Transform parent, Vector3 position, bool loopStatus = false)
        {
            Transform particleTransform = transform;
            particleTransform.parent = parent;
            particleTransform.position = position;
            _particleSystem.Play();

            if (loopStatus)
            {
                return;
            }


            float duration = _particleSystem.main.duration;
            DOVirtual.DelayedCall(duration, () => { PoolManager.Instance.dustParticlePool.ReturnObject(this); });
        }

        #endregion
    }
}