using System.Collections.Generic;
using Entity.Domain.InGame.Character.Enemy;
using UnityEngine;

namespace Entity.Domain.InGame.Battle.Wave
{
    public class WaveChecker : IRequestChangeNextWave
    {
        private int maxWave;
        private int currentWave;
        private WaveInitializer waveInitializer;
        public WaveChecker(int maxWave,string stageDataPass)
        {
            this.maxWave = maxWave;
            currentWave = 0;

            waveInitializer = new WaveInitializer(stageDataPass);
            waveInitializer.InitializeFirstWave();
        }
        public void RequestChangeNextWave(List<Enemy> enemies)
        {
            bool canExistEnemy=CheckExistEnemy(enemies);
            //‚Ü‚¾“G‚ª‚¢‚½‚ç‘ŠúƒŠƒ^[ƒ“
            if (canExistEnemy) return;

            currentWave++;

            if (currentWave == maxWave)
            {
                waveInitializer.InitializeLastWave();
                return;
            }

            waveInitializer.InitializeWave(currentWave);
        }
        private bool CheckExistEnemy(List<Enemy> enemies)
        {
            int enemyCount = enemies.Count;
            if (enemyCount <= 0)
            {
                return false;
            }
            return true;
        }
        public int CurrentWave()
        {
            return currentWave;
        }
    }
}