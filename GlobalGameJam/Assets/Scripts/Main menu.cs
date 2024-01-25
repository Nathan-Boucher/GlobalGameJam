using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] private GameObject main,credits,options;
public void PlayGame()
{
    SceneManager.LoadScene("MoveObject");
}
public void Options()
{
    main.SetActive(false);
    options.SetActive(true);
    credits.SetActive(false);
}

 public void Credits()
 {
  main.SetActive(false);
  options.SetActive(false);
  credits.SetActive(true);
 }
public void QuitGame()
{
    Application.Quit();
}

public void Return()
{
  main.SetActive(true);
  options.SetActive(false);
  credits.SetActive(false);
}

}
