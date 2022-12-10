using PathCreation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME_.Scripts.Extensions
{
    public class RoadScaler : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private PathCreator pathCreator;

        [SerializeField] private Transform road;
        [SerializeField] private Transform finish;

        #endregion

        #region Public Methods

        [Button("Scale Road")]
        public void ScaleRoad()
        {
            Vector3 localScale = road.localScale;
            localScale = new Vector3(localScale.x, localScale.y, pathCreator.path.length / 2 + 10);
            road.localScale = localScale;

            Vector3 position = road.position;
            position = new Vector3(position.x, position.y, position.z - 20);
            road.position = position;
            
            finish.position = Vector3.forward * pathCreator.path.length;
        }

        #endregion
    }
}