using Entity.Domain.InGame.Character.Player;
using Entity.Domain.InGame.Puzzle;
using UnityEngine;

namespace Entity.Domain.InGame.Effect
{
    public class Heal:IEffectable
    {
        public Heal(IHealable healable)
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