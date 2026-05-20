using System.Collections.Generic;
using Entity.Domain.InGame.Character.Enemy;
using Entity.Domain.InGame.Character.Player;
using Entity.Domain.InGame.Model;
using UnityEngine;

namespace Entity.Domain.InGame.Battle.Turn
{
    public class EnemyTurn : ITurn
    {
        private List<Enemy> enemies;
        private List<PlayerModel> players;
        public EnemyTurn(List<Enemy> enemies, List<PlayerModel> players)
        {
            this.enemies = enemies;
            this.players = players;
        }

        public void ExecuteTurn()
        {
            AttackPhase();
        }
        private void AttackPhase()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Attackable.Attack(players.ConvertAll(player => (IDamageable)player));
            }
        }
    }
}