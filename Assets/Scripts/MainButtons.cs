using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButtons : MonoBehaviour {

    Button button;
    int firstLevel;
    int mainMenu;

    private void Start()
    {
        
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(PressButton);
        firstLevel = 1;
        mainMenu = 0;
    }

    public void PressButton ()
    {
        switch (button.tag)
        {

            case "play":
                SceneManager.LoadScene(firstLevel);               
                break;

            case "quit":
                Application.Quit();
                break;

            case "ragequit":
                SceneManager.LoadScene(mainMenu);
                break;

            default:
                break;
        }
    }

}
