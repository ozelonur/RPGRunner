#region Header
// Developed by Onur ÖZEL
#endregion

using _GAME_.Scripts.Enums;
using _GAME_.Scripts.GlobalVariables;
using _ORANGEBEAR_.Scripts.Bears;
using TMPro;
using UnityEngine;

namespace _GAME_.Scripts.Bears
{
    public class GameUIBear : UIBear
    {
        #region Serialized Fields

        [Header("Worth Texts")]
        [SerializeField] private TMP_Text _attackWorthText;
        [SerializeField] private TMP_Text _defenceWorthText;
        [SerializeField] private TMP_Text _magicWorthText;
        

        #endregion

        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            if (status)
            {
                Register(CustomEvents.UpdateWorths, UpdateWorths);
            }

            else
            {
                UnRegister(CustomEvents.UpdateWorths, UpdateWorths);
            }
        }

        protected override void InitLevel(object[] args)
        {
            base.InitLevel(args);
            _attackWorthText.text = "ATTACK : 0";
            _defenceWorthText.text = "DEFENCE : 0";
            _magicWorthText.text = "MAGIC : 0";
        }

        private void UpdateWorths(object[] args)
        {
            GateType worthType = (GateType) args[0];
            int worth = (int) args[1];
            
            switch (worthType)
            {
                case GateType.ATTACK:
                    _attackWorthText.text = "ATTACK : " + worth;
                    break;
                case GateType.DEFENCE:
                    _defenceWorthText.text = "DEFENCE " + worth;
                    break;
                case GateType.MAGIC:
                    _magicWorthText.text = "MAGIC " + worth;
                    break;
                default:
                    Debug.Log("Wrong Gate Type");
                    break;
            }
        }

        #endregion
    }
}