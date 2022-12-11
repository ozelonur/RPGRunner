using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Interfaces;
using _ORANGEBEAR_.EventSystem;
using JetBrains.Annotations;
using UnityEngine;

namespace _GAME_.Scripts.Bears.Player
{
    public class SwordAttack : Bear
    {

        #region MonoBehaviour Methods

        private void OnTriggerEnter(Collider other)
        {
            if (!other.transform.IsChildOf(transform)) return;
            
            if (!other.TryGetComponent(out IEnemy enemy))
            {
                return;
            }

            print("Hit enemy");
            enemy.TakeDamage();
        }

        #endregion

        #region Private Methods

        [UsedImplicitly]
        private void ActivateAttack()
        {
        }

        [UsedImplicitly]
        private void FinishAttack()
        {
            Roar(CustomEvents.CanFollowPath, true);
            Roar(CustomEvents.CanMoveHorizontal, true);
        }

        #endregion
    }
}