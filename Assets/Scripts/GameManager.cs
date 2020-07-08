using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static bool GameEnded;

  public GameObject gameOverUI;
  public GameObject completeLevelUI;

  private void Start()
  {
    GameEnded = false;
  }

  // Update is called once per frame
  void Update()
  {
    if (GameEnded == true)
    {
      return;
    }
    if (PlayerStats.Lives <= 0)
    {
      EndGame();
    }
    if (Input.GetKeyDown(KeyCode.F1))
    {
      EndGame();
    }
    if (Input.GetKeyDown(KeyCode.F2))
    {
      WinLevel();
    }
  }

  private void EndGame()
  {
    GameEnded = true;
    gameOverUI.SetActive(true);
    GetComponent<PauseMenu>().enabled = false;
  }

  public void WinLevel()
  {
    GameEnded = true;
    completeLevelUI.SetActive(true);
    GetComponent<PauseMenu>().enabled = false;
  }
}
