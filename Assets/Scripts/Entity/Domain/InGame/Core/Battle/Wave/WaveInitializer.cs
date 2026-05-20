using System.Collections.Generic;
using System.Linq;
using Entity.Domain.InGame.Character;
using Entity.Domain.InGame.Character.Enemy;
using Entity.Domain.InGame.Core;
using Entity.Domain.InGame.Load;
using UnityEngine;

namespace Entity.Domain.InGame.Battle.Wave
{
    public class WaveInitializer
    {
        private StageDataLoader stageDataLoader;
        private StageDataStruct stageDatas;
        private EnemyCreater enemyCreater;
        public WaveInitializer(string actorWaveData)
        {
            stageDataLoader = new StageDataLoader(actorWaveData);
            enemyCreater = new EnemyCreater();
            stageDatas = new StageDataStruct();

            stageDatas = stageDataLoader.LoadStageData();
        }
        public void InitializeFirstWave()
        {
            var enemiesData = stageDatas.Stages[0];
            Dictionary<ActorEnemyField, Enemy> enemiesDic = new Dictionary<ActorEnemyField, Enemy>();

            foreach (var (enemyType, index) in enemiesData.Enemies.Select((e, i) => (e, i)))
            {
                var field = (ActorEnemyField)index;
                var enemy = enemyCreater.CreateEnemy(enemyType.Type);
                enemiesDic.Add(field, enemy);
            }

            CoreContext.ISetActor.SetEnemy(enemiesDic);
        }
        public void InitializeWave(int wave)
        {
            var enemiesData = stageDatas.Stages[wave];
            Dictionary<ActorEnemyField, Enemy> enemiesDic = new Dictionary<ActorEnemyField, Enemy>();

            foreach (var (enemyType, index) in enemiesData.Enemies.Select((e, i) => (e, i)))
            {
                var field = (ActorEnemyField)index;
                var enemy = enemyCreater.CreateEnemy(enemyType.Type);
                enemiesDic.Add(field, enemy);
            }

            CoreContext.ISetActor.SetEnemy(enemiesDic);
        }
        public void InitializeLastWave()
        {
            var enemiesData = stageDatas.Stages[stageDatas.Stages.Count-1];
            Dictionary<ActorEnemyField, Enemy> enemiesDic = new Dictionary<ActorEnemyField, Enemy>();

            foreach (var (enemyType, index) in enemiesData.Enemies.Select((e, i) => (e, i)))
            {
                var field = (ActorEnemyField)index;
                var enemy = enemyCreater.CreateEnemy(enemyType.Type);
                enemiesDic.Add(field, enemy);
            }

            CoreContext.ISetActor.SetEnemy(enemiesDic);
        }
    }
}