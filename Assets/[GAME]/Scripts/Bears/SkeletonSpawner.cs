using _GAME_.Scripts.Manager;
using _GAME_.Scripts.Models;
using _ORANGEBEAR_.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Bears
{
    public class SkeletonSpawner : Bear
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private SkeletonSpawnData[] skeletonSpawnDatas;

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

        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            if (status)
            {
                Register(GameEvents.OnGameStart, OnGameStart);
            }

            else
            {
                UnRegister(GameEvents.OnGameStart, OnGameStart);
            }
        }

        private void OnGameStart(object[] args)
        {
            foreach (SkeletonSpawnData data in skeletonSpawnDatas)
            {
                int index = Random.Range(0, data.spawnPoints.Length);
                Skeleton skeleton = _poolManager.skeletonPool.Get();
                skeleton.InitSkeleton(data.spawnPoints[index]);
            }
        }

        #endregion
    }
}