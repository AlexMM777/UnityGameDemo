using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace c0nd3v
{
    public static class FixCanvas
    {
        [InitializeOnLoadMethod]
        public static void InitializeOnLoad()
        {
            EditorApplication.update += Update1;
        }

        public static void Update1()
        {
            // 1. Open game view
            var gameView = EditorWindow.GetWindow(typeof(EditorWindow).Assembly.GetType("UnityEditor.GameView"));

            EditorApplication.update -= Update1;
            EditorApplication.update += Update2;
        }

        public static void Update2()
        {
            // 2. Open scene view
            var sceneView = EditorWindow.GetWindow(typeof(SceneView));

            // 3. Reload scene
            var scene = SceneManager.GetActiveScene();
            EditorSceneManager.OpenScene(scene.path);

            EditorApplication.update -= Update2;
        }
    }
}