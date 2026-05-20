using System.Collections.Generic;
using Entity.Domain.InGame.Core;
using UnityEngine;

namespace Entity.Domain.InGame.Puzzle
{
    public class ComboCommand
    {
        private List<Combo> combos;
        private int comboCount;
        public ComboCommand()
        {
            combos = new List<Combo>();
            comboCount = 0;
        }
        public void AddCombo(DropType drop,int dropCount)
        {
            var combo = new Combo(drop, dropCount);
            combos.Add(combo);
            comboCount++;
        }
        public List<Combo> GetCombos()
        {
            return combos;
        }
        public int GetComboCount()
        {
            return comboCount;
        }
    }
}