using UnityEngine;

namespace Entity.Domain.InGame.Character.Player
{
    public class PlayerHPModel:IDamageable,IHealable
    {
        private const int maxHp = 100;
        private const int minHp = 0;
        private int currentHp;
        private bool canDead;

        public PlayerHPModel()
        {
            currentHp=maxHp;
            canDead = false;
        }
        public void Damage(int amount)
        {
            var hp=currentHp-amount;
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

        public int GetCurrentHp()
        {
            return currentHp;
        }
    }
}