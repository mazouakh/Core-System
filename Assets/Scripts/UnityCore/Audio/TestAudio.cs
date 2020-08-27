using UnityEngine;

namespace UnityCore
{
    namespace Audio
    {
        public class TestAudio : MonoBehaviour
        {
            public AudioController audioController;
            
#if UNITY_EDITOR
            private void Update()
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    audioController.PlayAudio(AudioType.ST_MainMenu, true);
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    audioController.StopAudio(AudioType.ST_MainMenu, true);
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    audioController.RestartAudio(AudioType.ST_MainMenu, true);
                }
                
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    audioController.PlayAudio(AudioType.SFX_MouseClick1);
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    audioController.StopAudio(AudioType.SFX_MouseClick1);
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    audioController.RestartAudio(AudioType.SFX_MouseClick1);
                }
            }

#endif
        }
    }
}

