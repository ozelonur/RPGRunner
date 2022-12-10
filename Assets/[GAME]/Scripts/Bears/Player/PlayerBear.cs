using _GAME_.Scripts.Enums;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Manager;
using _GAME_.Scripts.ScriptableObjects;
using _ORANGEBEAR_.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Bears.Player
{
    public class PlayerBear : Bear
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private Transform modelParent;

        [Header("Configurations")] [SerializeField]
        private CharacterTypes defaultCharacterType;

        #endregion

        #region Private Variables

        private DataManager _dataManager;
        private CharacterData _characterData;

        private GameObject _currentCharacter;

        #endregion

        #region MonoBehaviour Methods

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
            if (Input.GetKeyDown(KeyCode.S))
            {
                TransformTheCharacter(CharacterTypes.Magic);
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
            Roar(CustomEvents.CanFollowPath, true);
            Roar(CustomEvents.CanMoveHorizontal, true);
        }

        #endregion

        #region Private Methods

        private void TransformTheCharacter(CharacterTypes characterType)
        {
            _characterData = _dataManager.GetCharacterData(characterType);
            
            Destroy(_currentCharacter);
            
            _currentCharacter = Instantiate(_characterData.characterModel, modelParent);
            
            Animator animator = _currentCharacter.GetComponent<Animator>();
            
            Roar(CustomEvents.GetAnimator, animator);
            
            Roar(CustomEvents.PlayPlayerAnimation, AnimationTypes.Run);
        }

        #endregion
    }
}