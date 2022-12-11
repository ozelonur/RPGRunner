using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Manager;
using _ORANGEBEAR_.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Bears
{
    public class SkeletonBattleController : Bear, IEnemy
    {
        #region Private Variables

        private SkeletonAnimateBear _skeletonAnimateBear;
        private Collider _collider;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _skeletonAnimateBear = GetComponent<SkeletonAnimateBear>();
            _collider = GetComponent<Collider>();
        }

        #endregion

        public void TakeDamage(params object[] args)
        {
            _collider.enabled = false;
            _skeletonAnimateBear.PlayDeathAnimation();
            FeelingManager.Instance.PlayBloodParticle(transform, transform.position + Vector3.up);
        }
        
        public void InitSkeletonBattleController()
        {
            _collider.enabled = true;
        }
    }
}