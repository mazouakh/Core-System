using UnityEngine;
using UnityCore.UI;
using UnityCore.Tweening;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    
    [SerializeField] private TabsGroup mainTabsGroup;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }else
            Destroy(this);
    }

    public void ActivateMenu(GameObject menu)
    {
        if (menu.GetComponent<IAnimation>() != null)
        {
            menu.GetComponent<IAnimation>().ResetDefault();
        }
        if (menu.GetComponent<FadeTween>() != null)
        {
            menu.GetComponent<FadeTween>().PlayAnimation(); //Fade In
        }
    }

    public void DisableMenu(GameObject menu)
    {
        if (menu.GetComponent<IAnimation>() != null)
        {
            if (menu.GetComponent<SlideTween>() != null)
            {
                SlideTween slideTween = menu.GetComponent<SlideTween>();
                
                switch (mainTabsGroup.nextTabDirection)
                {
                    case TabsGroup.NextTabDirection.Left:
                        slideTween.slideDirection = SlideTween.Direction.Left;
                        menu.GetComponent<IAnimation>().PlayAnimation();
                        break;
                    case TabsGroup.NextTabDirection.Right:
                        slideTween.slideDirection = SlideTween.Direction.Right;
                        menu.GetComponent<IAnimation>().PlayAnimation();
                        break;
                }
            }

            if (menu.GetComponent<FadeTween>() != null)
            {
                menu.GetComponent<FadeTween>().ResetDefault(); // Fade Out
            }
        }
    }
    
    public void ActivateElement(GameObject element)
    {
        element.SetActive(true);
    }

    public void DisableElement(GameObject element)
    {
        element.SetActive(false);
    }
}
