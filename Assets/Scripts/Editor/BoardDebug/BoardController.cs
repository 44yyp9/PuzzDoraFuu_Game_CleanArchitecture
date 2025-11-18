using Entity.Domain.InGame.Puzzle;
using Entity.Domain.InGame.Core;
using UnityEngine;
using System.IO;

namespace UniEditor
{
    public class BoardController
    {
        private string boardPath;

        public BoardController(string boardPath)
        {
            this.boardPath = boardPath;
        }
        public void DebugBorardLog(Board board,int x,int y)
        {
            var grid = board.GetGrid();
            Debug.Log(grid[x, y].ToString());
        }
        
        // Write Board to JSON (row-based)
        public void WriteJson(Board board)
        {
            var grid = board.GetGrid();
            int width = grid.GetLength(0);
            int height = grid.GetLength(1);

            BoardDTO dto = new BoardDTO();
            dto.width = width;
            dto.height = height;
            dto.board = new string[height];

            for (int y = 0; y < height; y++)
            {
                string[] row = new string[width];
                for (int x = 0; x < width; x++)
                {
                    row[x] = grid[x, y].ToString();
                }
                dto.board[y] = string.Join(",", row);
            }

            string json = JsonUtility.ToJson(dto, true);
            File.WriteAllText(boardPath, json);

#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif
        }

        // Read JSON → Board
        public Board GetJsonBoard()
        {
            if (!File.Exists(boardPath))
            {
                Debug.Log($"JSON file not found: {boardPath}");
                return null;
            }

            string json = File.ReadAllText(boardPath);
            BoardDTO dto = JsonUtility.FromJson<BoardDTO>(json);

            Board board = new Board(dto.width, dto.height);
            DropType[,] grid = new DropType[dto.width, dto.height];

            for (int y = 0; y < dto.height; y++)
            {
                string[] row = dto.board[y].Split(',');
                for (int x = 0; x < dto.width; x++)
                {
                    if (System.Enum.TryParse(row[x], out DropType drop))
                        grid[x, y] = drop;
                    else
                        grid[x, y] = DropType.Empty;
                }
            }

            board.SetGrid(grid);
            return board;
        }
    }

    [System.Serializable]
    public class BoardDTO
    {
        public int width;
        public int height;
        public string[] board; // each string = one row "A,B,C,D,E"
    }
}