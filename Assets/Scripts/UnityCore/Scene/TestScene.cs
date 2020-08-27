using UnityEngine;
using UnityCore.Menu;

namespace UnityCore {

    namespace Scene {

        public class TestScene : MonoBehaviour
        {

            public SceneController sceneController;

#region Unity Functions
#if UNITY_EDITOR
            private void Update() {
                if (Input.GetKeyUp(KeyCode.T)) {
                    sceneController.Load(SceneType.MainMenu, (_scene) => {Debug.Log("Scene ["+_scene+"] loaded from test script!");}, false, PageType.Loading);
                }
                if (Input.GetKeyUp(KeyCode.G)) {
                    sceneController.Load(SceneType.Game);
                }
                if (Input.GetKeyUp(KeyCode.B)) {
                    sceneController.Load(SceneType.MainMenu);
                }
            }
#endif
#endregion
        }
    }
}
