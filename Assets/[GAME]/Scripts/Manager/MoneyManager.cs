using _GAME_.Scripts.Entities;
using _ORANGEBEAR_.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Manager
{
    public class MoneyManager : Bear
    {
        #region Singleton

        public static MoneyManager Instance;

        #endregion

        #region Propertiess

        public MoneyData MoneyData { get; private set; }

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            MoneyData = MoneyData.Get();

            if (MoneyData == null)
            {
                MoneyData = new MoneyData();
                bool isSuccessful = MoneyData.Register();
                if (!isSuccessful)
                {
                    Debug.LogError("Failed to register MoneyData!!");
                }
            }

            MoneyData.Load();
        }

        #endregion

        #region Public Methods

        public void AddMoney(int amount)
        {
            MoneyData.AddMoney(amount);
        }
        
        public void SubtractMoney(int amount)
        {
            MoneyData.SubtractMoney(amount);
        }

        #endregion
    }
}