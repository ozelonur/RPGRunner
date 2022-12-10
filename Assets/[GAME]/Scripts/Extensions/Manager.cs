using _ORANGEBEAR_.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Extensions
{
    public class Manager<T> : Bear where T : Bear
    {
        #region Private Variables

        private static T _instance;

        #endregion

        #region Properties

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
                }

                return _instance;
            }
        }

        #endregion
    }
}