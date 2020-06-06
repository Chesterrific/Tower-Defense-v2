using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

  BuildManager buildManager;

  [Header("Node Options")]
  public Color hoverColor;
  public Color alarmColor;
  public Vector3 positionOffset;

  [HideInInspector]
  public GameObject turret;
  [HideInInspector]
  public TurretBlueprint turretBlueprint;
  [HideInInspector]
  public bool isUpgraded = false;



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
    BuildTurret(buildManager.GetTurretToBuild());

  }

  //Instantiate turret and store it into the node's turret variable.
  void BuildTurret(TurretBlueprint turretToBuild)
  {
    if (PlayerStats.Money < turretToBuild.cost)
    {
      Debug.Log("Not enough $$");
      return;
    }

    PlayerStats.Money -= turretToBuild.cost;
    Debug.Log("Turret built, Money left: " + PlayerStats.Money);

    GameObject t = (GameObject)Instantiate(turretToBuild.prefab, GetBuildPosition(), Quaternion.identity);

    //Store the turret into this node.
    turret = t;

    //Samething as abovem store turretToBuild blueprint onto node.
    turretBlueprint = turretToBuild;

    GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
    Destroy(effect, 5f);
  }

  public void UpgradeTurret()
  {
    if (PlayerStats.Money < turretBlueprint.upgradeCost)
    {
      Debug.Log("Not enough $$");
      return;
    }

    PlayerStats.Money -= turretBlueprint.upgradeCost;
    Debug.Log("Turret built, Money left: " + PlayerStats.Money);
    
    //Destroy old turret game object to make space for upgrade.
    Destroy(turret);

    GameObject t = (GameObject)Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
    turret = t;

    GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
    Destroy(effect, 5f);

    isUpgraded = true;
  }
}
