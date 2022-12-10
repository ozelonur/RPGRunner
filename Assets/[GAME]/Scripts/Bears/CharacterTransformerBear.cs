using _GAME_.Scripts.Bears.Player;
using _ORANGEBEAR_.EventSystem;
using JetBrains.Annotations;

namespace _GAME_.Scripts.Bears
{
    public class CharacterTransformerBear : Bear
    {
        #region Private Variables

        private PlayerBear _player;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _player = transform.parent.parent.GetComponent<PlayerBear>();
        }

        #endregion

        #region Private Methods

        [UsedImplicitly]
        private void TransformTheCharacter()
        {
            _player.TransformTheCharacter();
        }

        #endregion
    }
}