using UnityEngine;
using UnityEngine.UI;

namespace UnityCore
{
    namespace UI
    {
        public class LevelButton : MonoBehaviour
        {
            [SerializeField] private DetailsPanel detailsPanel;
            
            [Header("Level Button UI")] 
            [SerializeField] private Text levelTitleUI;
            [SerializeField] private Text levelDescriptionShortUI;
            [SerializeField] private Text LevelFilesUI;
            [SerializeField] private Text LevelGemsUI;
            
            [Header("Level Info")] 
            public string levelTitle;
            public string levelDescriptionShort;
            public string levelDescriptionLong;
            public string levelSecondaryMission;

            [Header("Level Stats")] 
            [SerializeField] private int score;
            [SerializeField] private int secretFilesTotal;
            [SerializeField] private int secretFilesCollected;
            [SerializeField] private int legendarySuitsTotal;
            [SerializeField] private int legendarySuitsCollected;
            [SerializeField] private int GemsTotal;
            [SerializeField] private int GemsCollected;
            
            #region Unity Functions

            private void Start()
            {
                // Setting Level Button Data
                levelTitleUI.text = levelTitle;
                levelDescriptionShortUI.text = levelDescriptionShort;
                LevelFilesUI.text = secretFilesCollected + "/" + secretFilesTotal;
                LevelGemsUI.text = GemsCollected + "/" + GemsTotal;
            }

            #endregion

            #region Public Functions

            public void UpdateDetailPanel()
            {
                // Setting Details Panel Data
                detailsPanel.SetTitle(levelTitle);
                detailsPanel.SetDescription(levelDescriptionLong);
                detailsPanel.SetSecondaryMission(levelSecondaryMission);
                
                detailsPanel.AddLevelStat("Highest Score", score.ToString());
                detailsPanel.AddLevelStat("Secret Files Collected", secretFilesCollected+"/"+secretFilesTotal);
                detailsPanel.AddLevelStat("Legendary Suits", legendarySuitsCollected+"/"+legendarySuitsTotal);
                detailsPanel.AddLevelStat("Gems Found", GemsCollected+"/"+GemsTotal);
            }

            public void ResetDetailPanel()
            {
                detailsPanel.ResetText();
            }

            #endregion
        }
    }
}