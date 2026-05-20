using UnityEngine;

namespace Entity.Domain.InGame.Character.Player
{
    public class PlayerHPModel:IDamageable,IHealable
    {
        private const int maxHp = 100;
        private const int minHp = 0;
        private int currentHp;
        private IShieldable shieldable;
        private bool canDead;

        public PlayerHPModel(IShieldable shieldable)
        {
            currentHp = maxHp;
            canDead = false;
            this.shieldable = shieldable;
        }
        public void Damage(int amount)
        {
            //シールドによるガード
            var damage = shieldable.GetShield() - amount;
            shieldable.Damage();
            if (damage >= 0) return;

            var hp=currentHp+damage;
            if (hp <= minHp)
            {
                //死亡判定
                currentHp = minHp;
                Dead();
            }
            else
            {
                currentHp = hp;
            }
        }
        public void Heal(int amount)
        {
            var hp=currentHp+amount;
            if (hp > maxHp)
            {
                hp = maxHp;
            }
            else
            {
                currentHp = hp;
            }
        }

        private void Dead()
        {
            canDead=true;
        }
        public bool GetDead()
        {
            return canDead;
        }
        public int GetCurrentHp()
        {
            return currentHp;
        }
    }
}