using System.Collections.Generic;
using Entity.Domain.InGame.Character.Player;
using UnityEngine;

namespace Entity.Domain.InGame.Character.Enemy
{
    public class SlimeAttack:IAttackable<IDamageable>
    {
        private int damagePoint = 10;
        public void Attack(List<IDamageable> taget)
        {
            int randomTaget = Random.Range(0, taget.Count);
            taget[randomTaget].Damage(damagePoint);
        }
    }
}