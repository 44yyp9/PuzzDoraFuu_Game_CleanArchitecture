using System.Collections.Generic;
using Entity.Domain.InGame.Effect;
using UnityEngine;

namespace Entity.Domain.InGame.Puzzle
{
    public class ComboResult
    {
        private List<IEffectable> commandOrder;
        private int comboCount;
        private int currentCombo;
        public ComboResult(List<IEffectable> commandOrder, int comboCount)
        {
            this.commandOrder = commandOrder;
            this.comboCount = comboCount;
            
            currentCombo = 0;
            Debug.Log(commandOrder.Count);
        }

        public IEffectable RequestUseCommand()
        {
            var commandLength=commandOrder.Count;
            //ここでnullを返すのはよくないのでは？
            if (currentCombo >= commandLength) return null;
            
            IEffectable effect = commandOrder[currentCombo];
            currentCombo++;
            return effect;
        }
        public int GetComboCount()
        {
            return comboCount;
        }
    }
}