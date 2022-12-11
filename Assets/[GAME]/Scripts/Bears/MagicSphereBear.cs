using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Manager;
using _ORANGEBEAR_.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Bears
{
    public class MagicSphereBear : Bear
    {
        #region Private Variables

        private ParticleBear _particleBear;
        private PoolManager _poolManager;

        private Rigidbody _rigidbody;
        private Collider _collider;

        private Transform _magicSphereTransform;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _magicSphereTransform = transform;
            _particleBear = GetComponent<ParticleBear>();
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        private void Start()
        {
            _poolManager = PoolManager.Instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEnemy enemy)) return;
            
            enemy.TakeDamage();
            _poolManager.magicParticlePool.ReturnObject(this);
        }

        #endregion

        #region Public Methods

        public void InitMagicSphere(Transform spawnPoint, Transform direction)
        {
            Vector3 rbVelocity;
            _magicSphereTransform.position = spawnPoint.position;
            _magicSphereTransform.rotation = spawnPoint.rotation;
            rbVelocity = direction.forward * 20f;
            _rigidbody.velocity = rbVelocity;
            _collider.enabled = true;
            _particleBear.Play(_magicSphereTransform, _magicSphereTransform.position);
        }

        #endregion
    }
}