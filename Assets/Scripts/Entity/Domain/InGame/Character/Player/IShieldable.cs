using UnityEngine;

namespace Entity.Domain.InGame.Character.Player
{
    public interface IShieldable
    {
        public void SetShield(int amount);
        public int GetShield();
        //ここ同じインターフェースに入れて良いものか？
        public void Damage();
    }
}