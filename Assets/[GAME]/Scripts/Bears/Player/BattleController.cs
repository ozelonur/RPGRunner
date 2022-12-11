using _GAME_.Scripts.Enums;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Interfaces;
using _ORANGEBEAR_.EventSystem;
using DG.Tweening;
using UnityEngine;

namespace _GAME_.Scripts.Bears.Player
{
    public class BattleController : Bear
    {
        #region Private Variables

        private PlayerAnimateBear _playerAnimateBear;
        private PlayerBear _playerBear;
        private bool _triggered;
        private int _health;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _playerBear = GetComponent<PlayerBear>();
            _playerAnimateBear = GetComponent<PlayerAnimateBear>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag($"Skeleton"))
            {
                if (_playerBear.defaultCharacterType != CharacterTypes.Magic)
                {
                    return;
                }

                _triggered = true;
                DOVirtual.DelayedCall(.3f, () => _triggered = false);
                Roar(CustomEvents.CanFollowPath, false);
                Roar(CustomEvents.CanMoveHorizontal, false);
                _playerAnimateBear.PlayAttackAnimation();
                return;
            }

            if (!other.TryGetComponent(out IEnemy enemy))
            {
                return;
            }

            if (_triggered)
            {
                return;
            }

            _triggered = true;
            DOVirtual.DelayedCall(.3f, () => _triggered = false);
            Roar(CustomEvents.CanFollowPath, false);
            Roar(CustomEvents.CanMoveHorizontal, false);
            _playerAnimateBear.PlayAttackAnimation();
        }

        #endregion
    }
}