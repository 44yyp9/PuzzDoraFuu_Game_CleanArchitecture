using UnityEngine;

namespace Entity.Domain.InGame.Character.Enemy
{
    public class EnemyStatusModel
    {
        private int attackPower;

        public EnemyStatusModel(int power)
        {
            attackPower = power;
        }
        public int GetAttackPower()
        {
            return attackPower;
        }
    }
}