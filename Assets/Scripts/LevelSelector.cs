using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
  public SceneFader sceneFader;

  public void Select(string levelName)
  {
    sceneFader.FadeTo(levelName);
  }
}
