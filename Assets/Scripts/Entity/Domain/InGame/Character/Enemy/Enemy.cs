using Entity.Domain.InGame.Character.Player;
using UnityEngine;

namespace Entity.Domain.InGame.Character.Enemy
{
    public class Enemy
    {
        public EnemyHPModel EnemyHpModel { get; private set; }
        public EnemyStatusModel EnemyStatusModel { get; private set; }
        public IAttackable<IDamageable>  Attackable { get; private set; }

        public Enemy(EnemyHPModel enemyHpModel, EnemyStatusModel enemyStatusModel,IAttackable<IDamageable> attackable)
        {
            EnemyHpModel = enemyHpModel;
            EnemyStatusModel = enemyStatusModel;
            Attackable = attackable;
        }
    }
}