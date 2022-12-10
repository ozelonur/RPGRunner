using System.Collections.Generic;
using _GAME_.Scripts.Models;

namespace _GAME_.Scripts.Interfaces
{
    public interface IWarrior
    {
        public List<CharacterWorthData> characterWorthData { get; set; }

        void HitToGate(params object[] args);
    }
}