using UnityEngine;

namespace Entity.Domain.InGame.Character.Player
{
    public class PlayerStatusModel:IShieldable
    {
        private int shieldPower;

        public PlayerStatusModel()
        {
            shieldPower = 0;
        }
        public void SetShield(int amount)
        {
            shieldPower = amount;
        }

        public int GetShield()
        {
            return shieldPower;
        }

        public void Damage()
        {
            shieldPower = 0;
        }
    }
}