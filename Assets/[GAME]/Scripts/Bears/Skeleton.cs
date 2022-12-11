using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Manager;
using _ORANGEBEAR_.EventSystem;
using DG.Tweening;
using UnityEngine;

namespace _GAME_.Scripts.Bears
{
    public class Skeleton : Bear
    {
        #region Private Variables

        private Transform _skeletonTransform;
        private SkeletonAnimateBear _skeletonAnimateBear;
        private SkeletonBattleController _skeletonBattleController;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _skeletonTransform = transform;
            _skeletonAnimateBear = _skeletonTransform.GetChild(0).GetChild(0).GetComponent<SkeletonAnimateBear>();
            _skeletonBattleController = _skeletonTransform.GetChild(0).GetChild(0).GetComponent<SkeletonBattleController>();
            _skeletonTransform.localScale = Vector3.zero;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IWarrior warrior))
            {
                return;
            }

            int percentage = Random.Range(0, 100);
            if (percentage > 60)
            {
                warrior.TakeDamage(Random.Range(5,10));
            }
            _skeletonAnimateBear.PlayAttackAnimation();
        }

        #endregion

        #region Public Variables

        public void InitSkeleton(Transform parent)
        {
            _skeletonBattleController.InitSkeletonBattleController();
            _skeletonTransform.parent = parent;
            _skeletonTransform.localPosition = Vector3.zero;
            _skeletonTransform.localEulerAngles = Vector3.zero;

            Vector3 position = _skeletonTransform.position;

            FeelingManager.Instance.PlayDustParticle(_skeletonTransform, position + Vector3.up);

            _skeletonTransform.position = position;
            _skeletonTransform.DOScale(Vector3.one, .3f)
                .SetEase(Ease.OutBack)
                .SetLink(_skeletonTransform.gameObject);
        }

        #endregion
    }
}