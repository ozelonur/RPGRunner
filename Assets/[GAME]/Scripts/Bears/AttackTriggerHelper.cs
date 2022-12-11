using _GAME_.Scripts.Bears.Player;
using _GAME_.Scripts.Interfaces;
using _ORANGEBEAR_.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Bears
{
    public class AttackTriggerHelper : Bear
    {
        #region Serialized Fields

        [SerializeField] private SwordAttack swordAttack;

        #endregion

        #region Private Variables

        private Collider _collider;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            swordAttack.SetTriggerHelper(this);
            
            DisableCollider();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEnemy enemy))
            {
                return;
            }
            
            swordAttack.Triggered(enemy);
            DisableCollider();
        }

        #endregion

        #region Public Methods

        public void EnableCollider()
        {
            _collider.enabled = true;
        }
        
        public void DisableCollider()
        {
            _collider.enabled = false;
        }

        #endregion
    }
}