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
            grid = new DropType[this.width, this.height];
        }
        public void SetGrid(DropType[,] grid)
        {
            this.grid = grid;
        }
        public void SetGridInPuzzle(int x,int y,DropType drop)
        {
            grid[x,y] = drop;
        }
        public DropType[,] GetGrid()
        {
            return this.grid;
        }
    }
}