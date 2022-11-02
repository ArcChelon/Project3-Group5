using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{

    public void OnLevelOneButtonClick()
    {
        //ButtonClick();
        SceneManager.LoadScene("Level_1");

    }
    public void OnLevelSelectButtonClick()
    {
        //ButtonClick();
        SceneManager.LoadScene("Level_Select");

    }
    public void OnHelpButtonClick()
    {
        //ButtonClick();
        SceneManager.LoadScene("Help");

    }
    public void OnCreditsButtonClick()
    {
        //ButtonClick();
        SceneManager.LoadScene("Credits");

    }
    public void OnMainMenuButtonClick()
    {
        //ButtonClick();
        SceneManager.LoadScene("Menu");

    }
    public void OnQuitButtonClick()
    {
        //ButtonClick();
        Application.Quit();

    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
