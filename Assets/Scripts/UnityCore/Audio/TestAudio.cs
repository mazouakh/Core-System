using System.Collections;
using System.Collections.Generic;
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
                /*if (Input.GetKeyDown(KeyCode.T))
                {
                    audioController.PlayAudio(AudioType.ST_01, true);
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    audioController.StopAudio(AudioType.ST_01, true);
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    audioController.RestartAudio(AudioType.ST_01, true);
                }
                
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    audioController.PlayAudio(AudioType.SFX_01);
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    audioController.StopAudio(AudioType.SFX_01);
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    audioController.RestartAudio(AudioType.SFX_01);
                }*/
            }

#endif
        }
    }
}

