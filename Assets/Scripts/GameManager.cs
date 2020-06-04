using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static bool GameEnded;

  public GameObject gameOverUI;

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
    if(Input.GetKeyDown(KeyCode.F1)){
      EndGame();
    }
  }

  private void EndGame()
  {
    GameEnded = true;
    gameOverUI.SetActive(true);
  }
}
