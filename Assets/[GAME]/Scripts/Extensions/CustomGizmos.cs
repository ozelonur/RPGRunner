using UnityEngine;

namespace _GAME_.Scripts.Extensions
{
    public class CustomGizmos: MonoBehaviour
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField] private Transform gizmoPoint;
        [SerializeField] private float radius = 0.5f;
        

        #endregion

        #region MonoBehaviour Methods

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(gizmoPoint.position, radius);
        }

        #endregion
       
    }
}