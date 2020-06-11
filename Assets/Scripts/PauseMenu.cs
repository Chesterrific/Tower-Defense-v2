using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  public GameObject pauseMenu;

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Pause))
    {
      Toggle();
    }
  }

  public void Toggle()
  {
    pauseMenu.SetActive(!pauseMenu.activeSelf);

    if (pauseMenu.activeSelf)
    {
      //Pauses the game.
      Time.timeScale = 0f;
    }
    else
    {
      //Unpause the game.
      Time.timeScale = 1f;
    }
  }

  public void Retry()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void Menu()
  {
    Debug.Log("Go to Menu");
  }
}
