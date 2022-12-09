using _GAME_.Scripts.Enums;
using _GAME_.Scripts.ScriptableObjects;
using _ORANGEBEAR_.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Manager
{
    public class DataManager : Bear
    {
        #region Singleton

        public static DataManager Instance;

        #endregion

        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private CharacterData[] characterDatas;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion

        #region Public Variables

        public CharacterData GetCharacterData(CharacterTypes characterType)
        {
            return characterDatas[(int)characterType];
        }

        #endregion
    }
}