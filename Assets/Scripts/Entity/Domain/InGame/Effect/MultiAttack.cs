using System.Collections.Generic;
using Entity.Domain.InGame.Character.Player;
using UnityEngine;

namespace Entity.Domain.InGame.Effect
{
    public class MultiAttack:IEffectable
    {
        public MultiAttack(List<IDamageable> damageables)
        {

        }
        public void Effect()
        {
            
        }
        public int GetDefaultPower()
        {
            return 0;
        }
        public void SetPower(int power)
        {
            
        }
    }
}