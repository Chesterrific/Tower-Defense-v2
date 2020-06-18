using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
  public Text roundsSurvived;

  private void OnEnable()
  {
    StartCoroutine(AnimateText());
  }

  IEnumerator AnimateText()
  {

    roundsSurvived.text = "0";
    int round = 0;

    yield return new WaitForSeconds(.7f);

    while (round < PlayerStats.Rounds)
    {
      round++;
      roundsSurvived.text = round.ToString();

      yield return new WaitForSeconds(.05f);
    }
  }
}
