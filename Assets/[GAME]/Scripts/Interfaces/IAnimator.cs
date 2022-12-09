using _GAME_.Scripts.Enums;
using _GAME_.Scripts.GlobalVariables;
using UnityEngine;

namespace _GAME_.Scripts.Interfaces
{
    public interface IAnimator
    {
        void PlayAnimation(AnimationTypes animationType);

        virtual void SetAnimation(Animator animator, AnimationTypes animationState)
        {
            int animState = (int) animationState;

            if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationState.ToString()))
            {
                animator.SetInteger(GlobalStrings.Player, animState);
            }
        }
    }
}