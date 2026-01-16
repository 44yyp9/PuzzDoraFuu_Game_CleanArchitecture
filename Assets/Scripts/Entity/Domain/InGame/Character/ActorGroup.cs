using System.Collections.Generic;
using Entity.Domain.InGame.Model;
using Entity.Domain.InGame.Character.Enemy;
using UnityEngine;
using Entity.Domain.InGame.Core;

namespace Entity.Domain.InGame.Character
{
    public class ActorGroup:ISetActorable,IProvideCharacterable,IRemoveCharacterable
    {
        private Dictionary<ActorPlayerField, PlayerModel> Players;
        private Dictionary<ActorEnemyField, Enemy.Enemy> Enemies;
        public void SetPlayer(Dictionary<ActorPlayerField, PlayerModel> players)
        {
            Players = players;
        }
        public void SetEnemy(Dictionary<ActorEnemyField, Enemy.Enemy> enemies)
        {
            Enemies = enemies;
        }

        public void RemoveEnemy(ActorEnemyField actor)
        {
            Enemies.Remove(actor);
        }
        public Enemy.Enemy GetEnemy()
        {
            return Enemies[0];
        }
        public List<Enemy.Enemy> GetAllEnemies()
        {
            var enemyList = new List<Enemy.Enemy>();
            foreach (var enemy in Enemies.Values)
            {
                enemyList.Add(enemy);
            }
            return enemyList;
        }
        public PlayerModel GetPlayer(ActorPlayerField actor)
        {
            return Players[actor];
        }
        public List<PlayerModel> GetAllPlayers()
        {
            var playerList = new List<PlayerModel>();
            foreach (var player in Players.Values)
            {
                playerList.Add(player);
            }
            return playerList;
        }
        public void RemovePlayer(ActorPlayerField actor)
        {
            Players.Remove(actor);
        }
    }
}