using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;
    public bool gamePaused = false;
    //Instance of GameManager
    public static GameManager instance;

    void Awake()
    {
        //Set the instance of this script
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 2.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        //Toggle Pause Menu
        UI.instance.TogglePauseMenu(gamePaused);

        //Toggle Mouse Cursor
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void AddScore(int score)
    {
        curScore += score;

        //Update Score text
        UI.instance.UpdateScoreText(curScore);

        //Have we reached the score to win?
        if(curScore >= scoreToWin)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        UI.instance.SetEndGameScreen(true, curScore);
    }

    public void LoseGame()
    {
        UI.instance.SetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }
}
