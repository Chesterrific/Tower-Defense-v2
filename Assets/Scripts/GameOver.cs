
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
  public Text roundsSurvived;

  private void OnEnable()
  {
    roundsSurvived.text = PlayerStats.Rounds.ToString();
  }

  public void Retry(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void Menu(){
    Debug.Log("Go to Menu");
  }
}
