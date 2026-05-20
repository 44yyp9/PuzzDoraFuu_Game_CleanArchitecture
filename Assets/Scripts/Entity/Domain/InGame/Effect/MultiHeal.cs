using System.Collections.Generic;
using Entity.Domain.InGame.Character.Player;
using UnityEngine;

namespace Entity.Domain.InGame.Effect
{
    public class MultiHeal:IEffectable
    {
        public MultiHeal(List<IHealable> healables)
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