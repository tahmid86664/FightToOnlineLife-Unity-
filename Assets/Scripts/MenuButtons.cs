using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public string stageScene;
    public string menuScene;
    public string openingMessageScene;

    public InputField inputField;
    public GameObject GenderPanel;
    public GameObject OpenMessagePanel;
    public Text errorText;

    public void Play()
    {
        SceneManager.LoadScene(stageScene);
    }

    public void ExitFormGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void OpeningMessage()
    {
        SceneManager.LoadScene(openingMessageScene);
    }

    public void ConfirmGender()
    {
        string text = inputField.text.ToString();
        
        if(text.ToUpper() == "MALE" || text.ToUpper() == "FEMALE")
        {
            GameManager.gender = text;
            GenderPanel.SetActive(false);
            OpenMessagePanel.SetActive(true);
            //Debug.Log(GameManager.gender);
        }
        else
        {
            errorText.text = "Plaase give appropriate information";
        }
        
    }

}
