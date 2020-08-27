using UnityEngine;
using UnityEngine.UI;

namespace UnityCore
{
    namespace UI
    {
        public class LevelStat : MonoBehaviour
        {
            [HideInInspector] public Text stateName;
            [HideInInspector] public Text stateValue;
            private void Awake()
            {
                stateName = transform.GetChild(0).GetComponent<Text>();
                stateValue = transform.GetChild(1).GetComponent<Text>();
            }
        }
    }
}