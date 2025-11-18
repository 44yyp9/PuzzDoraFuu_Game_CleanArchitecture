using Entity.Domain.InGame.Character.Player;
using UnityEngine;

namespace Entity.Domain.InGame.Character.Enemy
{
    public class GoblinFactory:EnemyFactory
    {
        private const int maxHp = 50;
        private const int power = 10;
        public override Enemy CreateEnemy()
        {
            EnemyHPModel enemyHpModel = new EnemyHPModel(maxHp);
            EnemyStatusModel enemyStatusModel = new EnemyStatusModel(power);
            IAttackable<IDamageable> goblinAttack = new GoblinAttack();
            return new Enemy(enemyHpModel, enemyStatusModel,goblinAttack);
        }
    }
}