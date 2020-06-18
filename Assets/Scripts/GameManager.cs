using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static bool GameEnded;

  public GameObject gameOverUI;
  public string nextLevel = "Level02";
  public int levelToUnlock = 2;
  public SceneFader sceneFader;

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

  public void WinLevel(){
    Debug.Log("Level won");
    PlayerPrefs.SetInt("levelReached", levelToUnlock);

    sceneFader.FadeTo(nextLevel);
  }
}
