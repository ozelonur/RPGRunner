#region Header

// Developed by Onur ÖZEL

#endregion

using _GAME_.Scripts.Enums;
using _GAME_.Scripts.GlobalVariables;
using _ORANGEBEAR_.Scripts.Bears;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _GAME_.Scripts.Bears
{
    public class GameUIBear : UIBear
    {
        #region Serialized Fields

        [Header("Worth Texts")] [SerializeField]
        private TMP_Text _attackWorthText;

        [SerializeField] private TMP_Text _defenceWorthText;
        [SerializeField] private TMP_Text _magicWorthText;

        [Header("Experience Bar")] [SerializeField]
        private Image _experienceBar;

        [SerializeField] private TMP_Text _experienceText;

        [Header("Health Bar")] [SerializeField]
        private Image _healthBar;

        [SerializeField] private TMP_Text _healthText;

        [Header("Info Text")] [SerializeField] private TMP_Text infoText;

        #endregion

        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            base.CheckRoarings(status);
            if (status)
            {
                Register(CustomEvents.UpdateWorths, UpdateWorths);
                Register(CustomEvents.UpdateExperienceBar, UpdateExperienceBar);
                Register(CustomEvents.UpdateHealthBar, UpdateHealthBar);
                Register(CustomEvents.OnFinishLine, OnFinishLine);
            }

            else
            {
                UnRegister(CustomEvents.UpdateWorths, UpdateWorths);
                UnRegister(CustomEvents.UpdateExperienceBar, UpdateExperienceBar);
                UnRegister(CustomEvents.UpdateHealthBar, UpdateHealthBar);
                UnRegister(CustomEvents.OnFinishLine, OnFinishLine);
            }
        }

        private void OnFinishLine(object[] args)
        {
            infoText.DOFade(1, 0.5f).SetLoops(6, LoopType.Yoyo)
                .OnComplete(() => infoText.DOFade(0, 0.5f).SetLink(gameObject)).SetLink(gameObject);
        }

        private void UpdateHealthBar(object[] args)
        {
            DOTween.Kill("HealthBarTween");
            int health = (int)args[0];
            _healthText.text = health.ToString();

            float experienceAmount = (float)health / 100;

            _healthBar.DOFillAmount(experienceAmount, .3f)
                .SetEase(Ease.Linear)
                .SetLink(_experienceBar.gameObject)
                .SetId("HealthBarTween");
        }

        private void UpdateExperienceBar(object[] args)
        {
            DOTween.Kill("ExperienceBarTween");
            int experience = (int)args[0];
            _experienceText.text = experience + " / 100";

            float experienceAmount = (float)experience / 100;

            _experienceBar.DOFillAmount(experienceAmount, .3f)
                .SetEase(Ease.Linear)
                .SetLink(_experienceBar.gameObject)
                .SetId("ExperienceBarTween");
        }

        protected override void InitLevel(object[] args)
        {
            base.InitLevel(args);
            infoText.DOFade(0, 0f).SetLink(gameObject);
            _attackWorthText.text = "ATTACK : 0";
            _defenceWorthText.text = "DEFENCE : 0";
            _magicWorthText.text = "MAGIC : 0";

            _experienceText.text = "0 / 100";
            _experienceBar.fillAmount = 0;
        }

        private void UpdateWorths(object[] args)
        {
            GateType worthType = (GateType)args[0];
            int worth = (int)args[1];

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