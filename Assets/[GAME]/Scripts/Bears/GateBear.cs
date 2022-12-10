using _GAME_.Scripts.Enums;
using _GAME_.Scripts.Interfaces;
using _ORANGEBEAR_.EventSystem;
using DG.Tweening;
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

        private void Awake()
        {
            InitGate();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IWarrior warrior))
            {
                return;
            }

            warrior.HitToGate(gateType, worth);
            DestroyGate();
        }

        #endregion

        #region Private Methods

        private void InitGate()
        {
            gateTitleText.text = gateType.ToString();

            gateHolder.color = worth >= 0 ? positiveColor : negativeColor;

            worthText.text = worth.ToString();
        }

        private void DestroyGate()
        {
            transform.DOLocalMoveY(-2, .3f)
                .OnComplete(() => { Destroy(gameObject); }).SetEase(Ease.InBack).SetLink(gameObject);
        }

        #endregion
    }
}