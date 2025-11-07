using UnityEditor;
using UnityEngine;

namespace UniEditor
{
    public class CreateCustomScriptWindow : EditorWindow
    {
        private string namespaceName = "MyNamespace"; // Default namespace
        private string namespaceTestCode = "MyNamespace";

        [MenuItem("Assets/Create/Custom C# CustomScript", false, 80)]
        public static void ShowWindow()
        {
            GetWindow<CreateCustomScriptWindow>("Create Custom Script");
        }

        private void OnGUI()
        {
            GUILayout.Label("General Custom Script Generator", EditorStyles.boldLabel);

            // Namespace input field
            namespaceName = EditorGUILayout.TextField("Namespace", namespaceName);

            // Button to generate script
            if (GUILayout.Button("Create Script"))
            {
                using (var generator = new CreateCustomScriptGenerator("Assets/Scripts/Editor/CustomScript/CustomTemplate.txt"))
                {
                    generator.CreateNewScript(namespaceName);
                } // Dispose() ‚ªŽ©“®‚ÅŒÄ‚Î‚ê‚é
            }
            GUILayout.Label("Test Code Script Generator", EditorStyles.boldLabel);

            // Namespace input field
            namespaceTestCode = EditorGUILayout.TextField("Namespace", namespaceTestCode);
            if (GUILayout.Button("Create Test Code"))
            {
                using (var generator = new CreateCustomScriptGenerator("Assets/Scripts/Editor/CustomScript/TestCodeTemplate.txt"))
                {
                    generator.CreateNewScript(namespaceTestCode);
                } // Dispose() ‚ªŽ©“®‚ÅŒÄ‚Î‚ê‚é
            }
        }
    }
}