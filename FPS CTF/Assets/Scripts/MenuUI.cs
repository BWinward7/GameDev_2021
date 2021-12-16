using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
