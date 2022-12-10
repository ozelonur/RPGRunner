using _GAME_.Scripts.Enums;
using _GAME_.Scripts.Extensions;
using _GAME_.Scripts.ScriptableObjects;
using UnityEngine;

namespace _GAME_.Scripts.Manager
{
    public class DataManager : Manager<DataManager>
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private CharacterData[] characterDatas;

        #endregion

        #region Public Variables

        public CharacterData GetCharacterData(CharacterTypes characterType)
        {
            return characterDatas[(int)characterType];
        }

        #endregion
    }
}