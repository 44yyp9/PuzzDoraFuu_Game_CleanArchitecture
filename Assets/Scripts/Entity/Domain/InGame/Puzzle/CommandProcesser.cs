using System.Collections.Generic;
using Entity.Domain.InGame.Core;
using System;
using Entity.Domain.InGame.Effect;
using Entity.Domain.InGame.Model;
using UnityEngine;
using Entity.Domain.InGame.Character;
using Entity.Domain.InGame.Character.Player;

namespace Entity.Domain.InGame.Puzzle
{
    /// <summary>
    /// このクラスではコンボの扱いのルールを適用して処理するクラス
    /// </summary>
    public class CommandProcesser
    {
        private List<Combo> comboOrder;
        private List<IEffectable> commadOrder;
        private IEffectable effectable;
        private Dictionary<DropType, Action<Combo>> dropProcessAction;
        private IProvideCharacterable provideCharacterable => CoreContext.IProvideCharacter;
        //ここはコンストラクタで差し替え
        private ActorPlayerField playerField;

        public CommandProcesser()
        {
            //ここに追加のドロップがあればルールの追加をする
            dropProcessAction = new Dictionary<DropType, Action<Combo>>()
            {
                { DropType.SingleAttack , ApplySingleAttackRule },
                { DropType.MultiAttack  , ApplyMultiAttackRule },
                { DropType.Heal         , ApplyHealRule },
                { DropType.Shield       , ApplyShieldRule },
            };
        }
        public List<IEffectable> ProcessCombo(List<Combo> comboOrder)
        {
            this.comboOrder=comboOrder;
            commadOrder=new List<IEffectable>();
            foreach (var combo in comboOrder)
            {
                dropProcessAction[combo.Drop](combo);
            }
            return commadOrder;
        }

        private void ApplySingleAttackRule(Combo combo)
        {
            effectable = new SingleAttack(provideCharacterable.GetEnemy().EnemyHpModel);
            var power = effectable.GetDefaultPower();
            power = (combo.DropCount / 3) * power;
            effectable.SetPower(power);
            commadOrder.Add(effectable);
        }

        private void ApplyMultiAttackRule(Combo combo)
        {
            effectable = new MultiAttack(provideCharacterable.GetAllEnemies().ConvertAll(enemy => (IDamageable)enemy.EnemyHpModel));
            var power = effectable.GetDefaultPower();
            power = (combo.DropCount / 3) * power;
            effectable.SetPower(power);
        }
        /// <summary>
        /// 5個以上のコンボなら全体回復にする
        /// 3~4個なら個人回復
        /// </summary>
        private void ApplyHealRule(Combo combo)
        {
            int dropCount = combo.DropCount;
            if (dropCount >= 5)
            {
                effectable = new MultiHeal(provideCharacterable.GetAllPlayers().ConvertAll(player =>(IHealable)player.PlayerHpModel));
                var power = effectable.GetDefaultPower();
                power = (combo.DropCount / 5) * power;
                effectable.SetPower(power);
                commadOrder.Add(effectable);
            }
            else if(dropCount >= 3)
            {
                effectable = new Heal(provideCharacterable.GetPlayer(playerField).PlayerHpModel);
                var power = effectable.GetDefaultPower();
                power = (combo.DropCount / 3) * power;
                effectable.SetPower(power);
                commadOrder.Add(effectable);
            }
        }
        /// <summary>
        /// 2個以上のシールドのコンボなら全体シールド
        /// </summary>
        private void ApplyShieldRule(Combo combo)
        {
            int count = 0;
            foreach (var _combo in comboOrder)
            {
                if (_combo.Drop == DropType.Shield)
                {
                    count++;
                }
            }

            if (count >= 2)
            {
                effectable = new MultiShield(provideCharacterable.GetAllPlayers().ConvertAll(player=>(IShieldable)player));
                var power = effectable.GetDefaultPower();
                effectable.SetPower(power);
                commadOrder.Add(effectable);
            }
            else if (count == 1)
            {
                effectable = new Shield(provideCharacterable.GetPlayer(playerField).PlayerStatusModel);
                var power = effectable.GetDefaultPower();
                effectable.SetPower(power);
                commadOrder.Add(effectable);
            }
        }
    }
}