using System.Collections.Generic;
using System.Linq;
using _GAME_.Scripts.Enums;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Manager;
using _GAME_.Scripts.Models;
using _GAME_.Scripts.ScriptableObjects;
using _ORANGEBEAR_.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Bears.Player
{
    public class PlayerBear : Bear, IWarrior
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private Transform modelParent;

        [Header("Configurations")] [SerializeField]
        public CharacterTypes defaultCharacterType;

        #endregion

        #region Private Variables

        private DataManager _dataManager;
        private CharacterData _characterData;

        private GameObject _currentCharacter;
        private Transform _playerTransform;

        private PlayerAnimateBear _playerAnimateBear;
        
        private CharacterTypes newCharacterType;

        private int _health = 100;

        #endregion

        #region Interface Variables

        [field: SerializeField] public List<CharacterWorthData> characterWorthData { get; set; }

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _playerAnimateBear = GetComponent<PlayerAnimateBear>();
            _playerTransform = transform;
        }

        private void Start()
        {
            _dataManager = DataManager.Instance;

            _characterData = _dataManager.GetCharacterData(defaultCharacterType);

            _currentCharacter = Instantiate(_characterData.characterModel, modelParent);

            Animator animator = _currentCharacter.GetComponent<Animator>();

            Roar(CustomEvents.GetAnimator, animator);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                TakeDamage(100);
            }
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
            Roar(CustomEvents.UpdateHealthBar, _health);
            Roar(CustomEvents.CanFollowPath, true);
            Roar(CustomEvents.CanMoveHorizontal, true);
        }

        #endregion

        #region Private Methods

        public void TransformTheCharacter()
        {
            _characterData = _dataManager.GetCharacterData(newCharacterType);
            
            FeelingManager.Instance.PlayDustParticle(_playerTransform,_playerTransform.position + Vector3.up);

            Destroy(_currentCharacter);

            _currentCharacter = Instantiate(_characterData.characterModel, modelParent);

            Animator animator = _currentCharacter.GetComponent<Animator>();

            defaultCharacterType = newCharacterType;

            Roar(CustomEvents.GetAnimator, animator);

            Roar(CustomEvents.PlayPlayerAnimation, AnimationTypes.Run);
        }

        private void CheckTransformation()
        {
            IOrderedEnumerable<CharacterWorthData> characterWorthDatas = characterWorthData.OrderBy(x => x.worth);

            CharacterWorthData data = characterWorthDatas.Last();
            

            switch (data.characterType)
            {
                case GateType.ATTACK:
                    newCharacterType = CharacterTypes.Sword;
                    _playerAnimateBear.PlayTransformAnimations(CharacterTypes.Sword, defaultCharacterType);
                    break;
                case GateType.DEFENCE:
                    newCharacterType = CharacterTypes.SwordAndShield;
                    _playerAnimateBear.PlayTransformAnimations(CharacterTypes.SwordAndShield, defaultCharacterType);
                    break;
                case GateType.MAGIC:
                    newCharacterType = CharacterTypes.Magic;
                    _playerAnimateBear.PlayTransformAnimations(CharacterTypes.Magic, defaultCharacterType);
                    break;
                default:
                    Debug.Log("No character type found");
                    break;
            }
        }

        #endregion

        public void HitToGate(params object[] args)
        {
            GateType gateType = (GateType)args[0];
            int worth = (int)args[1];

            characterWorthData.Find(x => x.characterType == gateType).worth += worth;

            CheckTransformation();

            Roar(CustomEvents.UpdateWorths, gateType, worth);
        }

        public void TakeDamage(params object[] args)
        {
            _playerAnimateBear.PlayAnimation(AnimationTypes.TakeDamage);
            _health -= (int)args[0];

            if (_health <= 0)
            {
                _health = 0;
                _playerAnimateBear.PlayDieAnimation();
            }
            
            Roar(CustomEvents.UpdateHealthBar, _health);
        }
    }
}