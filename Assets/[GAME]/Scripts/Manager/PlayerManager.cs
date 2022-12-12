using _GAME_.Scripts.Extensions;
using _GAME_.Scripts.Interfaces;

namespace _GAME_.Scripts.Manager
{
    public class PlayerManager : Manager<PlayerManager>
    {
        #region Public Variables

        public IWarrior warrior;

        #endregion

        #region Public Methods

        public void SetWarrior(IWarrior player)
        {
            warrior = player;
        }

        #endregion
    }
}