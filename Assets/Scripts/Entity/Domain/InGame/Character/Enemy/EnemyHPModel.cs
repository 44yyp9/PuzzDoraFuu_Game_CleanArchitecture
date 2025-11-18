using UnityEngine;
using Entity.Domain.InGame.Character.Player;

namespace Entity.Domain.InGame.Character.Enemy
{
    public class EnemyHPModel:IDamageable
    {
        private int maxHp;
        private int currentHP;
        private const int minHP = 0;
        private bool canDead;

        public EnemyHPModel(int HP)
        {
            maxHp = HP;
            currentHP = maxHp;
            canDead = false;
        }
        public void Damage(int amount)
        {
            var hp=currentHP-amount;
            if (hp <= minHP)
            {
                currentHP=minHP;
                Dead();
            }
            else
            {
                currentHP=hp;
            }
        }

        private void Dead()
        {
            canDead=true;
        }

        public int GetCurrentHP()
        {
            return currentHP;
        }
    }
}