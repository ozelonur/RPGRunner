using _GAME_.Scripts.Interfaces;
using _ORANGEBEAR_.EventSystem;
using JetBrains.Annotations;
using UnityEngine;

namespace _GAME_.Scripts.Bears.Boss
{
    public class BossSwordAttack : Bear
    {
        #region Private Variables

        private BossAttackTriggerHelper _attackTriggerHelper;

        #endregion

        #region Private Methods

        [UsedImplicitly]
        private void ActivateAttack()
        {
            _attackTriggerHelper.EnableCollider();
        }

        #endregion

        #region Public Methods

        public void Triggered(IWarrior enemy)
        {
            if (Random.Range(0,100) > 50)
            {
                enemy.TakeDamage(100);
            }
        }

        public void SetTriggerHelper(BossAttackTriggerHelper helper)
        {
            _attackTriggerHelper = helper;
        }

        #endregion
    }
}