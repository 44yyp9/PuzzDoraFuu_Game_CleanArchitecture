using System.Collections.Generic;
using Entity.Domain.InGame.Character.Enemy;
using Entity.Domain.InGame.Character.Player;
using Entity.Domain.InGame.Model;
using UnityEngine;

namespace Entity.Domain.InGame.Battle.Wave
{
    public class GameEndChecker
    {
        private GameClear gameClear;
        private GameOver gameOver;
        private GameEnd gameEnd;

        //ここはもしかしたら相互の参照取かねないので注意が必要
        //リファクタリング対象になるかも
        private int maxWave;
        private int currentWave;

        public GameEnd CeckGameEnd(List<PlayerModel> players,List<Enemy> enemies)
        {
            bool canExistPlayer=CheckExistPlayer(players);
            bool canExistEnemy = CheckExistEnemy(enemies);
            bool canCurrentMaxWave = maxWave == currentWave;

            //判定
            if (canExistPlayer&&!canExistEnemy&&canCurrentMaxWave)
            {
                //ゲームクリア条件
                gameEnd = new GameEnd(true, gameClear);
            }
            else if (!canExistPlayer)
            {
                //ゲームオーバー条件
                gameEnd= new GameEnd(true, gameOver);
            }
            else
            {
                //ゲームの続行
                gameEnd=new GameEnd(false, null);
            }

            return gameEnd;
        }
        private bool CheckExistPlayer(List<PlayerModel> players)
        {
            foreach (PlayerModel player in players)
            {
                PlayerHPModel playerHP=player.PlayerHpModel;
                if (!playerHP.GetDead())
                {
                    //もし誰か生きていたらtrueを返す
                    return true;
                }
            }
            //誰も生きていなかったらfalseを返す
            return false;
        }
        private bool CheckExistEnemy(List<Enemy> enemies)
        {
            int enemyCount=enemies.Count;
            if (enemyCount <= 0)
            {
                return false;
            }
            return true;
        }
    }
}