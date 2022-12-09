using _GAME_.Scripts.Enums;
using UnityEngine;

namespace _GAME_.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Character Data", menuName = "Data/Character Data", order = 1)]
    public class CharacterData : ScriptableObject
    {
        public CharacterTypes characterType;
        public GameObject characterModel;
    }
}