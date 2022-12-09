#region Header

// Developed by Onur ÖZEL

#endregion

namespace _GAME_.Scripts.GlobalVariables
{
    /// <summary>
    /// This class is used to store Custom Events that you create.
    /// </summary>
    public class CustomEvents
    {
        // Movement
        public const string GetPath = nameof(GetPath);
        public const string GetForwardSpeed = nameof(GetForwardSpeed);
        public const string CanFollowPath = nameof(CanFollowPath);
        public const string CanMoveHorizontal = nameof(CanMoveHorizontal);
        public const string OnFinishLine = nameof(OnFinishLine);
        public const string PlayPlayerAnimation = nameof(PlayPlayerAnimation);
        
        // Camera
        public const string SwitchCamera = nameof(SwitchCamera);
        public const string GetCameraFollowTarget = nameof(GetCameraFollowTarget);
        public const string GetAnimator = nameof(GetAnimator);
    }
}