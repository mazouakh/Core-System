using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityCore.Audio;
using AudioType = UnityCore.Audio.AudioType;

namespace UnityCore
{
    namespace UI
    {
        //This script changes only the appearance of the UI
        //Events are being handled by the Button UI component
        public class TilesGroup : MonoBehaviour
        {
            public List<TilesButton> tilesButtons;
            public List<GameObject> menusToSwap;
            public Color imageIdleColor;
            public Color imageActiveColor;
            public Color textIdleColor;
            public Color textActiveColor;
            [SerializeField] private float tweenDuration = .5f;

            private AudioController _audioController;
            private MenuController _menuController;
            private TilesButton _selectedTile;
            private int _oldSelectedTileIndex;

            #region Unity Functions

            private void Start()
            {
                _audioController = AudioController.instance;
                _menuController = MenuController.instance;
                
                if (tilesButtons[0].GetComponent<LevelButton>() != null)
                {
                    OnTileEnter(tilesButtons[0], false); // set the first level as selected by default on start
                }
            }

            #endregion
            
            #region Public Functions
            
            public void OnTileEnter(TilesButton tilesButton, bool _canPlayAudio = true)
            {
                ResetTiles();
                
                //Tweening & Audio
                //Play Tile Hover Audio PS: the audio first before the _selectedTile gets changed
                if (_canPlayAudio && _selectedTile != tilesButton) //if we hover on currently selected tiles do not play sound
                {
                    _audioController.PlayAudio(AudioType.SFX_UIHover);
                }
                //Tweening
                if (_selectedTile == null || tilesButton != _selectedTile)
                {
                    //Tweening animation
                    if (tilesButton.changeScale)
                        tilesButton.buttonImage.transform.DOScale(tilesButton.hoverScale, tilesButton.scaleDuration);
                    tilesButton.buttonImage.DOColor(imageActiveColor, tweenDuration);
                    tilesButton.highlightImage.enabled = true;
                    tilesButton.buttonTitle.DOColor(textActiveColor, tweenDuration);
                    if (tilesButton.buttonSubtitle)
                        tilesButton.buttonSubtitle.DOColor(textActiveColor,tweenDuration);

                    //if this is a level tile
                    if (tilesButton.GetComponent<LevelButton>() != null)
                    {
                        tilesButton.GetComponent<LevelButton>().ResetDetailPanel();
                        tilesButton.GetComponent<LevelButton>().UpdateDetailPanel();
                        OnTileSelected(tilesButton, false); //make this tile the selected one and stay selected
                                                                        //canPlayAudio false to not override 'hover' sound with 'select' sound
                    }
                }
                
            }

            public void OnTileExit(TilesButton tilesButton)
            {
                ResetTiles();
            }

            public void OnTileSelected(TilesButton tilesButton, bool _canPlayAudio=true)
            {
                if (tilesButton.enableSelection) //if selection is enabled for this Tile Button
                {
                    if (_selectedTile != null)
                    {
                        _oldSelectedTileIndex = _selectedTile.transform.GetSiblingIndex();
                    }
                    _selectedTile = tilesButton;
                    ResetTiles(); //reset all tiles except the new selected tile
                }
                
                //Tweening & Audio
                //Tweening
                //TODO animate tile when clicked
                //Play Tile Clicked Audio
                if (!_canPlayAudio) return;
                _audioController.PlayAudio(AudioType.SFX_UIClick1);
            }
            #endregion

            #region Private Functions
            
            private void ResetTiles() 
            {
                foreach (TilesButton tilesButton in tilesButtons)
                {
                    if (_selectedTile != null && tilesButton == _selectedTile)
                    {
                        continue;
                    } // dont reset the currently selected tab

                    //Tweening animation
                    if (tilesButton.changeScale)
                        tilesButton.buttonImage.transform.DOScale(new Vector3(1,1,1), tilesButton.scaleDuration);
                    tilesButton.buttonImage.DOColor(imageIdleColor, tweenDuration);
                    tilesButton.highlightImage.enabled = false;
                    tilesButton.buttonTitle.DOColor(textIdleColor, tweenDuration);
                    if (tilesButton.buttonSubtitle)
                        tilesButton.buttonSubtitle.DOColor(textIdleColor,tweenDuration);
                }
            }

            #endregion
        }
    }
}

