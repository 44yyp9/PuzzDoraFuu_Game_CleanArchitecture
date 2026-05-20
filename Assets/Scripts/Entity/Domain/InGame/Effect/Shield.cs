using Entity.Domain.InGame.Character.Player;
using UnityEngine;

namespace Entity.Domain.InGame.Effect
{
    public class Shield:IEffectable
    {
        public Shield(IShieldable shieldable)
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