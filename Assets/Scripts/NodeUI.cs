using UnityEngine;

public class NodeUI : MonoBehaviour
{
  public GameObject ui;

  private Node target;

  public void SetTarget(Node node){
    target = node;

    transform.position = target.GetBuildPosition();

    ui.SetActive(true);
  }

  public void Hide(){
    ui.SetActive(false);
  }
}
