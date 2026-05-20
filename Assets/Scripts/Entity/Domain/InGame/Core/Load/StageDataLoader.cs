using System;
using Entity.Domain.InGame.Character;
using Entity.Domain.InGame.Core;
using UnityEngine;

namespace Entity.Domain.InGame.Load
{
    public class StageDataLoader
    {
        private string stageDatapath;
        public StageDataLoader(string stageDatapath)
        {
            this.stageDatapath = stageDatapath;
        }
        public StageDataStruct LoadStageData()
        {
            var asset = Resources.Load<TextAsset>(stageDatapath);
            var data = JsonUtility.FromJson<StageDataStruct>(asset.text);

            ConvertEnemyType(data);
            return data;
        }

        /// <summary>
        /// string‚©‚çenum‚É•ÏŠ·
        /// </summary>
        private void ConvertEnemyType(StageDataStruct data)
        {
            for (int i = 0; i < data.Stages.Count; i++)
            {
                var stage = data.Stages[i];

                for (int j = 0; j < stage.Enemies.Count; j++)
                {
                    var enemy = stage.Enemies[j];
                    if (!Enum.TryParse(enemy.JsonType, out EnemyType result))
                    {
                        throw new Exception($"Invalid EnemyType : {enemy.JsonType}");
                    }
                    enemy.Type = result;
                    stage.Enemies[j] = enemy;
                }

                data.Stages[i] = stage;
            }
        }
    }
}