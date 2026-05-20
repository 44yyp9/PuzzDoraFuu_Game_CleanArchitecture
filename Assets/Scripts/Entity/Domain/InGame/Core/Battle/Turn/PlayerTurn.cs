using System.Collections.Generic;
using Entity.Domain.InGame.Character.Enemy;
using Entity.Domain.InGame.Model;
using UnityEngine;

namespace Entity.Domain.InGame.Battle.Turn
{
    public class PlayerTurn : ITurn
    {
        private PlayerModel playerModel;
        private BoardModel board;
        public PlayerTurn(PlayerModel playerModel,BoardModel board)
        {
            this.playerModel = playerModel;
            this.board = board;
        }

        public void ExecuteTurn()
        {
            //Ç±Ç±Ç«Ç§èëÇ≠Ç©îYÇÒÇ≈ÇÈÇÃÇ≈ç≈å„
        }
    }
}