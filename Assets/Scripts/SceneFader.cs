using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{

  public Image img;

  //Animation curve to control fade
  public AnimationCurve curve;

  void Start()
  {
    StartCoroutine(FadeIn());
  }

  public void FadeTo(string scene)
  {
    StartCoroutine(FadeOut(scene));
    
  }

  //Fade Scene in.
  IEnumerator FadeIn()
  {
    float t = 1f;

    while (t > 0)
    {
      //Decrease t by our time between frames, i.e. time it takes to draw frame.
      t -= Time.deltaTime;

      //Convert t into our curve value (t = x-axis, a = y-axis).
      float a = curve.Evaluate(t);

      img.color = new Color(0f, 0f, 0f, a);

      //Wait until the next frame and repeat this while loop.
      yield return 0;
    }
  }

  //Fade Scene out.
  IEnumerator FadeOut(string scene)
  {
    float t = 0f;

    while (t < 1f)
    {
      //Decrease t by our time between frames, i.e. time it takes to draw frame.
      t += Time.deltaTime;

      //Convert t into our curve value (t = x-axis, a = y-axis).
      float a = curve.Evaluate(t);

      img.color = new Color(0f, 0f, 0f, a);

      //Wait until the next frame and repeat this while loop.
      yield return 0;
    }
    SceneManager.LoadScene(scene);
  }
}
