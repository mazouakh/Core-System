using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace UnityCore
{
    namespace Menu
    {
        public class DetailsPanel : MonoBehaviour
        {
            [SerializeField] private Text title;
            [SerializeField] private Text description;
            [SerializeField] private Text secondaryMission;
            [SerializeField] private Transform statsBoard;
            [SerializeField] private GameObject statPrefab;

            private List<GameObject> _statGOs = new List<GameObject>();

            #region Unity Functions
            
            
            #endregion
            
            #region Public Functions

            public void SetTitle(string text)
            {
                title.text = text;
            }
            
            public void SetDescription(string text)
            {
                description.text = text;
            }

            public void SetSecondaryMission(string text)
            {
                secondaryMission.text = text;
            }
            
            public void AddLevelStat(string statName, string stateValue)
            {
                GameObject _statGO = Instantiate(statPrefab, statsBoard);
                _statGOs.Add(_statGO); //storing all gameObjects in a list
                LevelStat levelStat = _statGO.GetComponent<LevelStat>();
                levelStat.stateName.text = statName;
                levelStat.stateValue.text = stateValue;
            }
            
            public void ResetText()
            {
                SetTitle("");
                SetDescription("");
                SetSecondaryMission("");
                DeleteAllStats();
            }

            #endregion
            
            #region Private Functions

            private void DeleteAllStats()
            {
                foreach (GameObject statGO in _statGOs)
                {
                    Destroy(statGO);
                }
            }

            #endregion
        }
    }
}