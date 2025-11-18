using Entity.Domain.InGame.Model;
using Entity.Domain.InGame.Core;
using UnityEngine;
using UnityEditor;

namespace UniEditor
{
    public class BoardView
    {
        private BoardModel boardModel;
        private const float CellSize = 40f;
        private Vector2 scrollPos;
        private Vector2 origin = new Vector2(10, 10);

        public BoardView(BoardModel boardModel)
        {
            this.boardModel = boardModel;
        }

        public void Draw()
        {
            if (boardModel == null)
            {
                EditorGUILayout.HelpBox("BoardModelが設定されていません。", MessageType.Warning);
                return;
            }

            // スクロールビュー開始
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(300)); // 高さを固定

            var grid = boardModel.GetBoard().GetGrid();
            int width = grid.GetLength(0);
            int height = grid.GetLength(1);

            GUILayout.BeginVertical();
            GUILayout.Space(origin.y);

            float totalWidth = width * CellSize;
            float originX = (EditorGUIUtility.currentViewWidth - totalWidth) / 2f;
            origin.x = originX;

            // グリッド描画
            for (int y = 0; y <height; y++) // 下から上
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(origin.x);
                for (int x = 0; x < width; x++)
                {
                    DropType drop = grid[x, y];
                    Color prev = GUI.color;
                    GUI.color = GetColor(drop);

                    GUILayout.Box(drop.ToString(), GUILayout.Width(CellSize), GUILayout.Height(CellSize));

                    GUI.color = prev;
                }
                GUILayout.EndHorizontal();
            }

            GUILayout.EndVertical();

            // スクロールビュー終了
            EditorGUILayout.EndScrollView();
        }

        private Color GetColor(DropType drop)
        {
            switch (drop)
            {
                case DropType.SingleAttack: return Color.red;
                case DropType.MultiAttack: return Color.cyan;
                case DropType.Heal: return Color.green;
                case DropType.Shield: return Color.yellow;
                case DropType.Empty: return Color.white;
                default: return Color.gray;
            }
        }
    }
}