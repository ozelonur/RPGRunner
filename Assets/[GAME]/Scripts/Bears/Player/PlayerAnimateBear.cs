using _GAME_.Scripts.Enums;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Interfaces;
using _ORANGEBEAR_.EventSystem;
using DG.Tweening;
using UnityEngine;

namespace _GAME_.Scripts.Bears.Player
{
    public class PlayerAnimateBear : Bear, IAnimator
    {
        #region Private Variables

        private Animator _animator;
        private static readonly int Roll = Animator.StringToHash("Roll");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Die = Animator.StringToHash("Die");

        #endregion

        #region Interface Methods

        public void PlayAnimation(AnimationTypes animationType)
        {
            ((IAnimator)this).SetAnimation(_animator, animationType);
        }

        #endregion

        #region MonoBehaviour Methods

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _animator.SetTrigger(Roll);
            }
        }

        #endregion

        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            if (status)
            {
                Register(CustomEvents.GetAnimator, GetAnimator);
                Register(GameEvents.OnGameStart, OnGameStart);
                Register(CustomEvents.PlayPlayerAnimation, PlayPlayerAnimation);
            }

            else
            {
                UnRegister(CustomEvents.GetAnimator, GetAnimator);
                UnRegister(GameEvents.OnGameStart, OnGameStart);
                UnRegister(CustomEvents.PlayPlayerAnimation, PlayPlayerAnimation);
            }
        }

        private void PlayPlayerAnimation(object[] args)
        {
            PlayAnimation((AnimationTypes)args[0]);
        }

        private void GetAnimator(object[] args)
        {
            _animator = (Animator)args[0];
        }

        private void OnGameStart(object[] args)
        {
            PlayAnimation(AnimationTypes.Run);
        }

        #endregion

        #region Public Methods

        public void PlayTransformAnimations(CharacterTypes characterType, CharacterTypes defaultCharacterType)
        {
            if (characterType == defaultCharacterType)
            {
                return;
            }
            
            _animator.SetTrigger(Roll);
        }

        public void PlayAttackAnimation()
        {
            _animator.SetTrigger(Attack);
        }

        public void PlayDieAnimation()
        {
            _animator.SetTrigger(Die);
            Roar(CustomEvents.CanMoveHorizontal, false);
            Roar(CustomEvents.CanFollowPath, false);

            DOVirtual.DelayedCall(2f, () =>
            {
                Roar(GameEvents.OnGameComplete, false);
            });
        }

        #endregion
    }
}