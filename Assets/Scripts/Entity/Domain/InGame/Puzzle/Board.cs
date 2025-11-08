using Entity.Domain.InGame.Core;
using UnityEngine;

namespace Entity.Domain.InGame.Puzzle
{
    public class Board
    {
        private int width;
        private int height;
        private DropType[,] grid;
        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public void SetGrid(DropType[,] grid)
        {
            this.grid = grid;
        }
        public DropType[,] GetGrid()
        {
            return this.grid;
        }
    }
}