using _GAME_.Scripts.GlobalVariables;
using _ORANGEBEAR_.EventSystem;

namespace _GAME_.Scripts.Bears.Player
{
    public class PlayerBear : Bear
    {
        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            if (status)
            {
                Register(GameEvents.OnGameStart, OnGameStart);
            }

            else
            {
                UnRegister(GameEvents.OnGameStart, OnGameStart);
            }
        }

        private void OnGameStart(object[] args)
        {
            Roar(CustomEvents.CanFollowPath, true);
            Roar(CustomEvents.CanMoveHorizontal, true);
        }

        #endregion
    }
}