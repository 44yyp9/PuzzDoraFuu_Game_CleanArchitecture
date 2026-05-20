using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Entity.Domain.InGame.Model;
using Entity.Domain.InGame.Character.Player;

namespace Tests.Battle
{
    public class PlayerTest
    {
        private PlayerModel playerModel;
        private IHealable healable => playerModel.PlayerHpModel;
        private IDamageable damageable => playerModel.PlayerHpModel;
        private IShieldable shieldable=>playerModel.PlayerStatusModel;

        [Test]
        public void SurvivalPlayer()
        {
            playerModel = new PlayerModel();
            Assert.That(playerModel.PlayerHpModel.GetCurrentHp() == 100);
            healable.Heal(10);
            Assert.That(playerModel.PlayerHpModel.GetCurrentHp() == 100);
            damageable.Damage(10);
            Debug.Log(playerModel.PlayerHpModel.GetCurrentHp());
            Assert.That(playerModel.PlayerHpModel.GetCurrentHp() == 90);
            shieldable.SetShield(10);
            damageable.Damage(20);
            Assert.That(playerModel.PlayerHpModel.GetCurrentHp() == 80);
            healable.Heal(10);
            Assert.That(playerModel.PlayerHpModel.GetCurrentHp() == 90);
        }
        [Test]
        public void DeadPlayer()
        {
            playerModel = new PlayerModel();
            Assert.That(playerModel.PlayerHpModel.GetDead()==false);
            damageable.Damage(110);
            Assert.That(playerModel.PlayerHpModel.GetCurrentHp() == 0);
            Assert.That(playerModel.PlayerHpModel.GetDead() == true);
        }
    }
}
