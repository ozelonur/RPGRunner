using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Interfaces;
using _ORANGEBEAR_.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Bears.Player
{
    public class BattleController : Bear
    {
        #region Private Variables

        private PlayerAnimateBear _playerAnimateBear;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _playerAnimateBear = GetComponent<PlayerAnimateBear>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEnemy enemy))
            {
                return;                
            }
            Roar(CustomEvents.CanFollowPath, false);
            Roar(CustomEvents.CanMoveHorizontal, false);
            _playerAnimateBear.PlayAttackAnimation();
        }

        #endregion
        
        
    }
}