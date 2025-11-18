using UnityEngine;

namespace Entity.Domain.InGame.Character.Player
{
    public interface IHealable
    {
        public void Heal(int amount);
    }
}