using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{

  public Image img;
  public GameObject startLevelScreen = null;
  private Animator animator = null;

  //Animation curve to control fade
  public AnimationCurve curve;

  void Start()
  {
    StartCoroutine(FadeIn());
  }

  private void Update()
  {
    if (startLevelScreen == null || !startLevelScreen.activeSelf || animator == null)
    {
      return;
    }
    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && animator.GetCurrentAnimatorStateInfo(0).IsName("StartLevelScreen"))
    {
      startLevelScreen.SetActive(false);
    }
  }

  public void FadeTo(string scene)
  {
    StartCoroutine(FadeOut(scene));
  }

  //Fade Scene in. Fades out this element.
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

    if (startLevelScreen == null)
    {
      yield break;
    }

    startLevelScreen.SetActive(true);
    animator = startLevelScreen.GetComponent<Animator>();
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
