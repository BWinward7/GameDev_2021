using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagment;

public class UI : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI scoreText;
    public Image healthBarFill;
    [Header("Pause Menu")]
    public GameObject pauseMenu;
    [Header("End Game Screen")]
    public GameObject endGameScreen;
    public TextMeshProUGUI endGameHeaderText;
    public TextMeshProUGUI endGameScoreText;

    // Instance
    public static GameUI instance;
    void Awake()
    {
        instance = this;
    }

    public void UpdateHealthBar(int curHP, int maxHP)
    {
        healthBarFill.fillAmount = (float)curHP / (float)maxHP;
    }

    public void UdapteScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UdpateAmmoText(int curAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo: " + curAmmo + " / " + maxAmmo;
    }

    public void TogglePauseMenu( bool paused)
    {
        TogglePauseMenu.SetActive(paused);
    }

    public void SetEndGameScreen(bool won, int score)
    {
        endGameScreen.SetActive(true);
        endGameHeaderText.text = won == true ? "You Win" : "You Lose";
        endGameHeaderText.text = won == true ? Color.green : Color.red;
        endGameHeaderText.text = "<b>score</b>\n" +score;
    }

    public void OnResumeButton()
    {

    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnMenuButton()
    {
        SceneManage.LoadScene("Menu");
    }
}
