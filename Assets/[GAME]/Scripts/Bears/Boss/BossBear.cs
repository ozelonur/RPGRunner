using System.Collections;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Manager;
using _ORANGEBEAR_.EventSystem;
using DG.Tweening;
using UnityEngine;

namespace _GAME_.Scripts.Bears.Boss
{
    public class BossBear : Bear, IEnemy
    {
        #region Serialized Fields
        [SerializeField] private int health;
        
        [Header("Components")][SerializeField]
        private GameObject[] bossPrefabs;

        #endregion

        #region Private Variables

        private GameObject _currentBoss;
        private BossAnimateBear _bossAnimateBear;
        private PlayerManager _playerManager;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _currentBoss = bossPrefabs[0];
            _bossAnimateBear = _currentBoss.GetComponent<BossAnimateBear>();
        }

        private void Start()
        {
            _playerManager = PlayerManager.Instance;
            BossManager.Instance.boss = this;
        }

        #endregion

        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            if (status)
            {
                Register(CustomEvents.OnFinishLine, OnFinishLine);
            }

            else
            {
                UnRegister(CustomEvents.OnFinishLine, OnFinishLine);
            }
        }

        private void OnFinishLine(object[] args)
        {
            StartCoroutine(Attack());
        }

        #endregion

        #region Private Methods

        private IEnumerator Attack()
        {
            IWarrior warrior = _playerManager.warrior;
            
            while (!warrior.IsDead && health > 0)
            {
                transform.LookAt(warrior.GetTransform());
                _bossAnimateBear.PlayAttackAnimation();
                yield return new WaitForSeconds(3f);
            }
        }

        #endregion

        public void TakeDamage(params object[] args)
        {
            health = 0;
            _bossAnimateBear.PlayDieAnimation();
            Roar(CustomEvents.GetExperience, 10);
            GetComponent<Collider>().enabled = false;
            FeelingManager.Instance.PlayBloodParticle(transform, transform.position + Vector3.up);
            
            DOVirtual.DelayedCall(2f, () =>
            {
                Roar(GameEvents.OnGameComplete, true);
                Destroy(gameObject);
            });
        }
    }
}