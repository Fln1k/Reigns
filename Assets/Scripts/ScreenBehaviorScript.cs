using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenBehaviorScript : MonoBehaviour
{
    public Button _NewGame;
    public Button _Quit;
    public Button _Settings;
    public Button _Spravka;

    private void Start()
    {
        _NewGame.onClick.AddListener(NewGame);
        _Quit.onClick.AddListener(Quit);
        _Settings.onClick.AddListener(Settings);
        _Spravka.onClick.AddListener(Spravka);

    }

    public void Settings()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Spravka()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
