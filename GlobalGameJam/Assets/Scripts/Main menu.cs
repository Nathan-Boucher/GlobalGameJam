using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] private GameObject main, options;
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Options()
    {
        main.SetActive(false);
        options.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

