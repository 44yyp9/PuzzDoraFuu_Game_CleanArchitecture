using Entity.Domain.InGame.Core;
using Entity.Domain.InGame.Model;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Domain.InGame.Character
{
    public interface ISetActorable
    {
        public void SetPlayer(Dictionary<ActorPlayerField, PlayerModel> players);
        public void SetEnemy(Dictionary<ActorEnemyField, Enemy.Enemy> enemies);
    }
}