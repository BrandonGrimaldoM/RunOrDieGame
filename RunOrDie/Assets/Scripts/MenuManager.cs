using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager sharedInstance;
    public Canvas menuCanvas;
    public Canvas infoCanvas;

    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        
    }

    public void ShowMainMenu()
    {
        menuCanvas.enabled = true;
    }

    public void HideMainMenu()
    {
        menuCanvas.enabled = false;
    }

    public void ShowInfoMenu()
    {
        infoCanvas.enabled = true;
    }

    public void HideInfoMenu()
    {
        infoCanvas.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
      #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
      #else
          Application.Quit();
      #endif
    }
}
