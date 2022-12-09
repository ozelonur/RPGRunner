#region Header
// Developed by Onur ÖZEL
#endregion

using _GAME_.Scripts.GlobalVariables;
using _ORANGEBEAR_.Scripts.Bears;
using PathCreation;
using UnityEngine;

namespace _GAME_.Scripts.Bears
{
    public class GameLevelBear : LevelBear
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private PathCreator pathCreator;
        [SerializeField] private EndOfPathInstruction endOfPathInstruction;
        [SerializeField] private Transform cameraFollowTarget;

        #endregion

        #region MonoBehaviour Methods

        private void Start()
        {
            Roar(CustomEvents.GetPath, pathCreator, endOfPathInstruction);
            Roar(CustomEvents.GetCameraFollowTarget, cameraFollowTarget);
        }

        #endregion
    }
}