using System.Collections.Generic;
using System;
using UnityEngine;
using Entity.Domain.InGame.Core;

namespace Entity.Domain.InGame.Character
{
    [Serializable]
    public struct StageDataStruct
    {
        public List<StageData> Stages;
    }
    [Serializable]
    public struct StageData
    {
        public int Stage;
        public List<EnemyData> Enemies;
    }
    [System.Serializable]
    public struct EnemyData
    {
        public string JsonType;
        [NonSerialized]
        public EnemyType Type;
    }
}