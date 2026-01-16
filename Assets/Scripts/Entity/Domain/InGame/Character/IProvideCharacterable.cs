using Entity.Domain.InGame.Core;
using Entity.Domain.InGame.Model;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Entity.Domain.InGame.Character
{
    public interface IProvideCharacterable
    {
        public Enemy.Enemy GetEnemy();
        public List<Enemy.Enemy> GetAllEnemies();
        public PlayerModel GetPlayer(ActorPlayerField actor);
        public List<PlayerModel> GetAllPlayers();
    }
}