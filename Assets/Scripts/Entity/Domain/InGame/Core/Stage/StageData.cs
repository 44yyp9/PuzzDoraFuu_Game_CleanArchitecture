using UnityEngine;

namespace Entity.Domain.InGame.Stage
{
    public class StageData
    {
        public int MaxWave {  get; private set; }
        public string StagePath {  get; private set; }
        public StageData(int maxWave, string stagePath)
        {
            MaxWave = maxWave;
            StagePath = stagePath;
        }
    }
}