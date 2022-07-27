using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Main Menu Panel List")]
    public GameObject MainPanel;
    public GameObject TimerPanel;
    public GameObject SelectPanel;
    public GameObject HTPPanel;

    public GameObject[] ball;
    //public int selectedBall = 0;

    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        TimerPanel.SetActive(false);
        SelectPanel.SetActive(false);
        HTPPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SinglePlayerButton()
    {
        GameData.instance.isSinglePlayer = true;
        TimerPanel.SetActive(true);
        SoundManager.instance.UIClickSfx();
    }

    public void MultiPlayerButton()
    {
        GameData.instance.isSinglePlayer = false;
        TimerPanel.SetActive(true);
        SoundManager.instance.UIClickSfx();
    }

    public void BackButton()
    {
        TimerPanel.SetActive(false);
        SelectPanel.SetActive(false);
        HTPPanel.SetActive(false);
        SoundManager.instance.UIClickSfx();
    }

    public void SetTimerButton(float Timer)
    {
        GameData.instance.gameTimer = Timer;
        TimerPanel.SetActive(false);
        SelectPanel.SetActive(true);
        SoundManager.instance.UIClickSfx();
    }

    public void SelectBallUI(int selectedBall = 0)
    {
        PlayerPrefs.SetInt("selectedBall", selectedBall);
        SoundManager.instance.UIClickSfx();
        SelectPanel.SetActive(false);
        HTPPanel.SetActive(true);

    }

    public void StartBtn()
    {
        SoundManager.instance.UIClickSfx();
        SceneManager.LoadScene("Gameplay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
