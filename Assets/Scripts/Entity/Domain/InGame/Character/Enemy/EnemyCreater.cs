using System.Collections.Generic;
using Entity.Domain.InGame.Core;
using UnityEngine;

namespace Entity.Domain.InGame.Character.Enemy
{
    public class EnemyCreater
    {
        private Dictionary<EnemyType, EnemyFactory> enemyPairs;
        public EnemyCreater()
        {
            enemyPairs = new Dictionary<EnemyType, EnemyFactory>()
            {
                {EnemyType.Goblin, new GoblinFactory() },
                {EnemyType.Slime, new SlimeFactory() }
            };
        }
        public Enemy CreateEnemy(EnemyType enemy)
        {
            return enemyPairs[enemy].CreateEnemy();
        }
    }
}