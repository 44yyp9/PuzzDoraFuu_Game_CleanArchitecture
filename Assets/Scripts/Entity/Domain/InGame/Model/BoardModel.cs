using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entity.Domain.InGame.Puzzle;

namespace Entity.Domain.InGame.Model
{
    public class BoardModel
    {
        private ComboChecker comboChecker;
        public BoardModel()
        {
            comboChecker = new ComboChecker();
        }
        public void ControlledPuzzle()
        {
            comboChecker.Check();
        }

    }
}
