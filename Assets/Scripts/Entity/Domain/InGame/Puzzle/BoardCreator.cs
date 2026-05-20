using System.Collections.Generic;
using Entity.Domain.InGame.Core;
using UnityEngine;

namespace Entity.Domain.InGame.Puzzle
{
    public class BoardCreator
    {
        private int width;
        private int height;
        private DropType[,] grid;
        private DropType[] dropArray;
        public BoardCreator(Board board)
        {
            grid = board.GetGrid();
            width = board.GetGrid().GetLength(0);
            height = board.GetGrid().GetLength(1);

            dropArray = new DropType[]
            {
                DropType.SingleAttack,
                DropType.MultiAttack,
                DropType.Heal,
                DropType.Shield
            };
        }
        public Board CreateBoard(Board board)
        {
            var generateBord = FactoryBorad(board);
            return generateBord;
        }
        private Board FactoryBorad(Board board)
        {
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    int random= Random.Range(0, dropArray.Length);
                    grid[i,j]=dropArray[random];

                    for(int _checkCount = 0; _checkCount < 4; _checkCount++)
                    {
                        if (CheckSameDropLine(i, j, board)) break;
                        random = Random.Range(0, dropArray.Length);
                        grid[i, j] = dropArray[random];
                    }
                }
            }
            board.SetGrid(grid);
            return board;
        }
        /// <summary>
        /// �R���{���Ă��Ȃ��̃`�F�b�N
        /// </summary>
        private bool CheckSameDropLine(int x,int y,Board board)
        {
            DropType current = grid[x, y];

            if (x >= 2 && grid[x - 1, y] == current && grid[x - 2, y] == current)
                return false;

            if (y >= 2 && grid[x, y - 1] == current && grid[x, y - 2] == current)
                return false; 
            //�����Ɉ���������Ȃ����true��Ԃ�
            return true;
        }
    }
}