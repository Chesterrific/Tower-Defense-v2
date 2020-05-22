using UnityEngine;

public class Node : MonoBehaviour
{
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
  }

  void OnMouseEnter()
  {
    //We grab this object's renderer component "Mesh Renderer" to grab its material to change here.
    rend.material.color = hoverColor;
  }

  void OnMouseExit()
  {
    rend.material.color = originalColor;
  }

  void OnMouseDown()
  {
    //If turret is already in place.
    if (turret != null)
    {
      Debug.Log("Turret already in place.");
      return;
    }

    //Build turret.
    GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
    turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

  }
}
