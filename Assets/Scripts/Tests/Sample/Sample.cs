using System.Collections;
using System.Collections.Generic;
using Entity.Domain.InGame.Battle.Wave;
using Entity.Domain.InGame.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.Sample
{
    public class Sample
    {
        [Test]
        public void SampleTest()
        {
            CoreContext.Initialize();

            var init = new WaveInitializer("InGame/StageData/Stage1");
            init.InitializeLastWave();

            Debug.Log(CoreContext.IProvideCharacter.GetEnemy().EnemyHpModel.GetCurrentHP());
        }
    }
}
