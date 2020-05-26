using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

  BuildManager buildManager;

  [Header("Node Options")]
  public Color hoverColor;
  public Vector3 positionOffset;

  /*Private Variables*/
  private GameObject turret;
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

  void OnMouseEnter()
  {
    //Built in Unity function that checks if our mouse is over a game object like U.I.
    if (EventSystem.current.IsPointerOverGameObject())
    {
      return;
    }

    if (buildManager.GetTurretToBuild() == null)
    {
      return;
    }

    //We grab this object's renderer component "Mesh Renderer" to grab its material to change here.
    rend.material.color = hoverColor;
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

    if (buildManager.GetTurretToBuild() == null)
    {
      return;
    }

    //If turret is already in place.
    if (turret != null)
    {
      Debug.Log("Turret already in place.");
      return;
    }

    //Build turret.
    GameObject turretToBuild = buildManager.GetTurretToBuild();
    turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

  }
}
