using Entity.Domain.InGame.Core;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Entity.Domain.InGame.Character
{
    public interface IRemoveCharacterable
    {
        public void RemoveEnemy(ActorEnemyField actor);
        public void RemovePlayer(ActorPlayerField actor);
    }
}