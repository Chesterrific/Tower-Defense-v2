
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
  public Text roundsSurvived;
  public string menuSceneName = "MainMenu";
  public SceneFader sceneFader;

  private void OnEnable()
  {
    roundsSurvived.text = PlayerStats.Rounds.ToString();
  }

  public void Retry(){
    sceneFader.FadeTo(SceneManager.GetActiveScene().name);
  }

  public void Menu(){
    sceneFader.FadeTo(menuSceneName);
  }
}
