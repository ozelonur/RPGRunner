using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Manager;
using _ORANGEBEAR_.EventSystem;
using JetBrains.Annotations;
using UnityEngine;

namespace _GAME_.Scripts.Bears.Player
{
    public class MagicAttack : Bear
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private Transform magicSphereSpawnPoint;

        #endregion

        #region Private Variables

        private PoolManager _poolManager;

        #endregion

        #region MonoBehaviour Methods

        private void Start()
        {
            _poolManager = PoolManager.Instance;
        }

        #endregion

        #region Private Methods

        [UsedImplicitly]
        private void Attack()
        {
            MagicSphereBear magicSphereBear = _poolManager.magicParticlePool.Get();
            magicSphereBear.InitMagicSphere(magicSphereSpawnPoint, transform);
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