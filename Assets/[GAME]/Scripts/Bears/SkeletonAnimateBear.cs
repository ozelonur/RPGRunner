using _ORANGEBEAR_.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Bears
{
    public class SkeletonAnimateBear : Bear
    {
        #region Private Variables

        private Animator _animator;
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Die = Animator.StringToHash("Die");

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        #endregion

        #region Public Methods

        public void PlayAttackAnimation()
        {
            _animator.SetTrigger(Attack);
        }
        
        public void PlayDeathAnimation()
        {
            _animator.SetTrigger(Die);
        }

        #endregion
    }
}