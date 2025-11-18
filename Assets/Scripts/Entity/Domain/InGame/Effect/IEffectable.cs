using UnityEngine;

namespace Entity.Domain.InGame.Effect
{
    public interface IEffectable
    {
        public void Effect();
        public int GetDefaultPower();
        public void SetPower(int power);
    }
}