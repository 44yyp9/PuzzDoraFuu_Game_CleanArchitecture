using UnityEngine;

namespace Entity.Domain.InGame.Character.Player
{
    public interface IDamageable
    {
        public void Damage(int amount);
    }
}