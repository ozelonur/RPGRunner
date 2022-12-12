using System.Collections.Generic;
using _GAME_.Scripts.Models;
using UnityEngine;

namespace _GAME_.Scripts.Interfaces
{
    public interface IWarrior
    {
        public bool IsDead { get; set; }
        public List<CharacterWorthData> characterWorthData { get; set; }

        void HitToGate(params object[] args);
        void TakeDamage(params object[] args);
        
        Transform GetTransform();
    }
}