using Entity.Domain.InGame.Model;
using UnityEngine;
using UnityEditor;

namespace UniEditor
{
    public class BoardDebugWindow:EditorWindow
    {
        BoardModel boardModel;
        private BoardView boardView;
        private BoardController boardController;
        private int debugX;
        private int debugY;
        
        private string jsonPath = "Assets/Scripts/Editor/BoardDebug/Data/Board.json";
        [MenuItem("Tools/BoardWindow")]
        public static void ShowWindow()
        {
            GetWindow<BoardDebugWindow>("Debug Board Window");
        }
        private void OnGUI()
        {
            ShowBoard();
            UpdateBoard();
        }

        private void ShowBoard()
        {
            if (boardView != null)
            {
                boardView.Draw();
            }
            GUILayout.Space(10);

            // --- ボタンを横並び（中央寄せ） ---
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Generate", GUILayout.Width(100), GUILayout.Height(30)))
            {
                // 後で差し替え予定
                boardModel = new BoardModel();
                boardView = new BoardView(boardModel);
            }

            GUILayout.Space(10); // ボタン間の余白

            if (GUILayout.Button("Check", GUILayout.Width(100), GUILayout.Height(30)))
            {
                boardModel.ControlledPuzzle(boardModel.GetBoard());
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("Debug Position", EditorStyles.boldLabel);

            debugX = EditorGUILayout.IntField("X", debugX);
            debugY = EditorGUILayout.IntField("Y", debugY);
            if (GUILayout.Button("Print Cell Value", GUILayout.Height(25)))
            {
                if (boardModel != null)
                {
                    boardController = new BoardController(jsonPath);
                    boardController.DebugBorardLog(boardModel.GetBoard(), debugX, debugY);
                }
                else
                {
                    Debug.LogWarning("Board is not generated yet!");
                }
            }
            EditorGUILayout.EndVertical();
        }

        private int comboCount;
        private void UpdateBoard()
        {
            if(boardModel==null) return;
            
            jsonPath = EditorGUILayout.TextField("JsonPath", jsonPath);
            if (GUILayout.Button("Convert Json"))
            {
                boardController = new BoardController(jsonPath);
                boardController.WriteJson(boardModel.GetBoard());
            }

            if (GUILayout.Button("Apply Board"))
            {
                boardModel.ControlledPuzzle(boardController.GetJsonBoard());
                boardView=new BoardView(boardModel);
                boardView.Draw();
                
                comboCount = boardModel.GetComboResult().GetComboCount();
            }
            GUILayout.Space(10);
            
            GUILayout.Label("Combo Result", EditorStyles.boldLabel);
            // ★ GUI にコンボ数を表示
            GUILayout.Label($"Combo : {comboCount}", EditorStyles.helpBox);
        }
    }
}