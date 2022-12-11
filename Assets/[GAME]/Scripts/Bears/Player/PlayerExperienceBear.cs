using _GAME_.Scripts.GlobalVariables;
using _ORANGEBEAR_.EventSystem;

namespace _GAME_.Scripts.Bears.Player
{
    public class PlayerExperienceBear : Bear
    {
        #region Private Variables

        private int _experience;

        #endregion

        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            if (status)
            {
                Register(CustomEvents.GetExperience, GetExperience);
            }

            else
            {
                UnRegister(CustomEvents.GetExperience, GetExperience);
            }
        }

        private void GetExperience(object[] args)
        {
            _experience += (int) args[0];
            Roar(CustomEvents.UpdateExperienceBar, _experience);
        }

        #endregion
    }
}