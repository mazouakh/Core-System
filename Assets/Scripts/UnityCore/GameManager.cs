using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int targetFPS = 60;

#if UNITY_EDITOR
    private void Start()
    {
        Application.targetFrameRate = targetFPS;
    }
#endif
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
