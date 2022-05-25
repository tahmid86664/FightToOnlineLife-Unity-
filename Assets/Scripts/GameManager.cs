using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public string stageScene;
    public string gameOverSceneCovid;
    public string gameOverScene;
    public string menuScene;
    public string congtratulationScene;
    public bool unlockMouseCursor = false;

    //for gender
    public static string gender;

    //death zone
    public bool inZone = false;

    // Start is called before the first frame update
    void Start()
    {
        gm = this.gameObject.GetComponent<GameManager>();
    }

    public void LoadGameOverSceneCovid()
    {
        unlockMouseCursor = true;
        SceneManager.LoadScene(gameOverSceneCovid);
    }

    public void LoadGameOverScene()
    {
        unlockMouseCursor = true;
        SceneManager.LoadScene(gameOverScene);
    }

    public void LoadStageScene()
    {
        SceneManager.LoadScene(stageScene);
    }

    public void LoadMenuScene()
    {
        unlockMouseCursor = true;
        SceneManager.LoadScene(menuScene);
    }

    public void LoadCongtratulationScene()
    {
        unlockMouseCursor = true;
        SceneManager.LoadScene(congtratulationScene);
    }
}
