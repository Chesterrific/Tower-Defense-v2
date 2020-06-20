using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
  public Text startScreenText;

  private Scene scene;

  private void Start() {
    scene = SceneManager.GetActiveScene();
    string levelName = scene.name.ToString();

    startScreenText.text = "LEVEL " + levelName.Substring(levelName.LastIndexOf('-')+1);
  }
}
