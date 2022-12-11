using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Interfaces;
using _ORANGEBEAR_.EventSystem;
using JetBrains.Annotations;

namespace _GAME_.Scripts.Bears.Player
{
    public class SwordAttack : Bear
    {
        #region Private Variables

        private AttackTriggerHelper _attackTriggerHelper;

        #endregion
        #region Private Methods

        [UsedImplicitly]
        private void ActivateAttack()
        {
            _attackTriggerHelper.EnableCollider();
        }

        [UsedImplicitly]
        private void FinishAttack()
        {
            Roar(CustomEvents.CanFollowPath, true);
            Roar(CustomEvents.CanMoveHorizontal, true);
        }

        #endregion

        #region Public Methods

        public void Triggered(IEnemy enemy)
        {
            enemy.TakeDamage();
        }

        public void SetTriggerHelper(AttackTriggerHelper helper)
        {
            _attackTriggerHelper = helper;
        }

        #endregion
    }
}