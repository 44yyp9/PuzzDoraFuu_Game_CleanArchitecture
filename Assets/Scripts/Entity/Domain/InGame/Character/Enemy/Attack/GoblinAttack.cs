using System.Collections.Generic;
using Entity.Domain.InGame.Character.Player;
using UnityEngine;

namespace Entity.Domain.InGame.Character.Enemy
{
    public class GoblinAttack:IAttackable<IDamageable>
    {
        private int damagePoint = 20;
        public void Attack(List<IDamageable> taget)
        {
            int randomTaget = Random.Range(0, taget.Count);
            taget[randomTaget].Damage(damagePoint);
        }
    }
}