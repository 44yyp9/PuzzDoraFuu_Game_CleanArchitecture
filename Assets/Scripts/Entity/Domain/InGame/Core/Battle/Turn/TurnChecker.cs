using System.Collections.Generic;
using Entity.Domain.InGame.Battle.Wave;
using Entity.Domain.InGame.Stage;
using Entity.Domain.InGame.Core;
using Entity.Domain.InGame.Model;
using UnityEngine;

namespace Entity.Domain.InGame.Battle.Turn
{
    public class TurnChecker : IManageTurnable
    {
        private GameEndChecker endChecker;
        private WaveChecker waveChecker;
        private BoardModel boardModel;
        private List<PlayerModel> players;
        private List<ITurn> turns;
        private int currentTurnLoop;
        private StageData stageData;
        public TurnChecker(List<PlayerModel> players,BoardModel boardModel, StageData stageData)
        {
            this.players = players;
            this.boardModel = boardModel;
            this.stageData = stageData;

            endChecker = new GameEndChecker();
            waveChecker = new WaveChecker(this.stageData.MaxWave,this.stageData.StagePath);

            foreach (PlayerModel player in players)
            {
                ITurn turn=new PlayerTurn(player,this.boardModel);
                turns.Add(turn);
            }
            ITurn enemyTurn = new EnemyTurn(CoreContext.IProvideCharacter.GetAllEnemies(), CoreContext.IProvideCharacter.GetAllPlayers());
            turns.Add(enemyTurn);

            currentTurnLoop = 0;
        }
        public void ManageTurn()
        {
            //Ç†ÇÒÇ‹ÇËÇÊÇÎÇµÇ≠Ç»Ç¢whileÉãÅ[Év
            bool canGameEnd=false;
            while (canGameEnd)
            {
                var gameEnd = endChecker.CeckGameEnd(CoreContext.IProvideCharacter.GetAllPlayers(), CoreContext.IProvideCharacter.GetAllEnemies());
                canGameEnd = gameEnd.CanGameEnd;

                waveChecker.RequestChangeNextWave(CoreContext.IProvideCharacter.GetAllEnemies());

                ExecuteTurnAction();
            }
        }
        private void ExecuteTurnAction()
        {
            ITurn cuurentTurn=turns[currentTurnLoop];
            cuurentTurn.ExecuteTurn();
            currentTurnLoop++;
            if(currentTurnLoop==turns.Count) currentTurnLoop = 0;
        }
    }
}