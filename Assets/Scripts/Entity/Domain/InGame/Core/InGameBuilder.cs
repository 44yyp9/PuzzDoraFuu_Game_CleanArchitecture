using System.Collections.Generic;
using Entity.Domain.InGame.Battle.Turn;
using Entity.Domain.InGame.Model;
using Entity.Domain.InGame.Stage;
using UnityEngine;

namespace Entity.Domain.InGame.Core
{
    public class InGameBuilder
    {
        private TurnChecker turnChecker;
        private BoardModel boardModel;
        private List<PlayerModel> players;
        private StageData stageData;
        public InGameBuilder(List<PlayerModel> players)
        {
            this.players = players;
        }
        public void StartInGame()
        {
            CoreContext.Initialize();
            boardModel = new BoardModel();
            turnChecker = new TurnChecker(players,boardModel,stageData);
            turnChecker.ManageTurn();
            //whileÉãÅ[ÉvÇ±Ç±Ç≈Ç‚ÇÈ

            //presenter

        }
    }
}