using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entity.Domain.InGame.Puzzle;

namespace Entity.Domain.InGame.Model
{
    public class BoardModel
    {
        private const int width = 5;
        private const int height = 6;

        private Board board;
        private BoardCreator creator;
        private ComboChecker checker;
        private ComboResult result;

        public BoardModel()
        {
            board = new Board(width, height);
            creator=new BoardCreator(board);
            checker = new ComboChecker();

            board = creator.CreateBoard(board);
        }
        public void ControlledPuzzle(Board resultBoard)
        {
            board = resultBoard;
            result=checker.GetComboResult(resultBoard);
        }
        public Board GetBoard()
        {
            return board;
        }
        public ComboResult GetComboResult()
        {
            return result;
        }
    }
}
