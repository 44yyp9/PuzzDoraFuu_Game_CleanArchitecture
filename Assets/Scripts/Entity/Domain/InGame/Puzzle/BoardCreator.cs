using Entity.Domain.InGame.Core;
using UnityEngine;

namespace Entity.Domain.InGame.Puzzle
{
    public class BoardCreator
    {
        private int width;
        private int height;
        private DropType[,] grid;
        private ComboChecker checker;
        public BoardCreator(Board board)
        {
            grid = board.GetGrid();
            width = board.GetGrid().GetLength(0);
            height = board.GetGrid().GetLength(1);

            checker = new ComboChecker();
        }
        public Board CreateBoard(Board board)
        {
            var result = checker.CheckCombo();

            return null;
        }
    }
}