using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace UniEditor
{
    public class CreateCustomScriptGenerator : IDisposable
    {
        private const string DefaultScriptName = "NewScript.cs";
        private string TemplatePath = "Assets/Scripts/Editor/CustomScript/CustomTemplate.txt";
        private const string ScriptsFolderPath = "Assets/Scripts/";
        private bool disposed = false;
        public CreateCustomScriptGenerator(string textPath)
        {
            this.TemplatePath = textPath;
        }

        public void CreateNewScript(string namespaceName)
        {
            string selectedPath = GetSelectedPath();
            string filePath = ShowSaveFilePanel(selectedPath);

            if (string.IsNullOrEmpty(filePath))
            {
                // User cancelled the save operation
                return;
            }

            string scriptNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            CreateScriptFile(filePath, scriptNameWithoutExtension, namespaceName);
            AssetDatabase.Refresh();
        }

        private string GetSelectedPath()
        {
            string path = "Assets";
            foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
            {
                path = AssetDatabase.GetAssetPath(obj);
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    path = Path.GetDirectoryName(path);
                    break;
                }
            }
            return path;
        }

        private string ShowSaveFilePanel(string initialPath)
        {
            return EditorUtility.SaveFilePanelInProject(
                "Save Script",
                DefaultScriptName,
                "cs",
                "Please enter a file name to save the script to.",
                initialPath
            );
        }

        private void CreateScriptFile(string filePath, string scriptName, string namespaceName)
        {
            if (!File.Exists(TemplatePath))
            {
                Debug.LogError($"Template not found at: {TemplatePath}");
                return;
            }

            string templateContent = File.ReadAllText(TemplatePath);
            templateContent = templateContent.Replace("#SCRIPTNAME#", scriptName);
            templateContent = templateContent.Replace("#NAMESPACE#", namespaceName);

            File.WriteAllText(filePath, templateContent);
        }
        public void Dispose()
        {
            if (disposed) return;

            // ÉäÉ\Å[ÉXâï˙Ç™Ç†ÇÍÇŒÇ±Ç±Ç…
            disposed = true;
            Debug.Log("Dispose");
        }
    }
}