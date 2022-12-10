using _GAME_.Scripts.Enums;
using _GAME_.Scripts.Interfaces;
using _ORANGEBEAR_.EventSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _GAME_.Scripts.Bears
{
    public class GateBear : Bear
    {
        #region Serialized Fields

        [Header("Configurations")] [SerializeField]
        private GateType gateType;

        [SerializeField] private int worth;
        [SerializeField] private Color positiveColor;
        [SerializeField] private Color negativeColor;

        [Header("Components")] [SerializeField]
        private Image gateHolder;

        [SerializeField] private TMP_Text worthText;
        [SerializeField] private TMP_Text gateTitleText;

        #endregion

        #region MonoBehaviour Methods

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IWarrior warrior))
            {
                return;
            }
            
            
        }

        #endregion

        #region Private Methods

        private void InitGate()
        {
            
        }

        #endregion
    }
}