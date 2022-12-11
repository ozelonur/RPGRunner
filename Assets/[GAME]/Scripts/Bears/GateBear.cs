using _GAME_.Scripts.Enums;
using _GAME_.Scripts.Interfaces;
using _ORANGEBEAR_.EventSystem;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _GAME_.Scripts.Bears
{
    public class GateBear : Bear
    {
        #region Serialized Fields

        [Header("Configurations")] [SerializeField]
        private GateType gateType;

        [SerializeField] private int worth;
        [SerializeField] private Material positiveMaterial;
        [SerializeField] private Material negativeMaterial;
        [SerializeField] private Material positiveHolderMaterial;
        [SerializeField] private Material negativeHolderMaterial;
        [SerializeField] private Renderer[] gateRenderers;
        [SerializeField] private Renderer holderRenderer;

        [Header("Components")] [SerializeField]
        private TMP_Text worthText;

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

            if (worth >= 0)
            {
                foreach (Renderer gRenderer in gateRenderers)
                {
                    gRenderer.material = positiveMaterial;
                }

                holderRenderer.material = positiveHolderMaterial;
            }

            else
            {
                foreach (Renderer gRenderer in gateRenderers)
                {
                    gRenderer.material = negativeMaterial;
                }

                holderRenderer.material = negativeHolderMaterial;
            }

            if (worth < 0 )
            {
                worthText.text = "- " + worth;
            }

            else
            {
                worthText.text = "+ " + worth;
            }
        }

        private void DestroyGate()
        {
            transform.DOLocalMoveY(-2, .3f)
                .OnComplete(() => { Destroy(gameObject); }).SetEase(Ease.InBack).SetLink(gameObject);
        }

        #endregion
    }
}