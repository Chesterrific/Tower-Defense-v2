using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

  BuildManager buildManager;

  [Header("Node Options")]
  public Color hoverColor;
  public Color alarmColor;
  public Vector3 positionOffset;

  [Header("Optional")]
  public GameObject turret;

  /*Private Variables*/
  private Renderer rend;
  private Color originalColor;

  void Start()
  {
    //Optimize performance by basically caching this component at the start rather than finding it everytime we mouse over something.
    rend = GetComponent<Renderer>();
    originalColor = rend.material.color;

    //Store buildManager instance for ease of use.
    buildManager = BuildManager.instance;
  }

  public Vector3 GetBuildPosition()
  {
    return transform.position + positionOffset;
  }

  void OnMouseEnter()
  {
    //Built in Unity function that checks if our mouse is over a game object like U.I.
    if (EventSystem.current.IsPointerOverGameObject())
    {
      return;
    }

    if (!buildManager.CanBuild)
    {
      return;
    }

    if (buildManager.HasMoney)
    {
      rend.material.color = hoverColor;
    }
    else
    {
      rend.material.color = alarmColor;
    }
    //We grab this object's renderer component "Mesh Renderer" to grab its material to change here.

  }
  void OnMouseExit()
  {
    rend.material.color = originalColor;
  }

  void OnMouseDown()
  {
    if (EventSystem.current.IsPointerOverGameObject())
    {
      return;
    }

    //If turret is already in place.
    if (turret != null)
    {
      buildManager.SelectNode(this);
      return;
    }

    if (!buildManager.CanBuild)
    {
      return;
    }

    //Build turret.
    buildManager.BuildTurretOn(this);

  }
}
