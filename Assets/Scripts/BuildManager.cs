using UnityEngine;

public class BuildManager : MonoBehaviour
{
  /*Singleton Style*/
  //To make things simplier, we only want one build manager available to everyone. We create a static variable that we instantiate on game start.
  public static BuildManager instance;

  private void Awake()
  {
    if (instance != null)
    {
      Debug.Log("Build Manager is already instantiated");
      return;
    }
    instance = this;
  }

  [Header("Build Manager Options")]
  public GameObject standardTurretPrefab;

  private GameObject turretToBuild;

  private void Start()
  {
    //Temporarily set turretToBuild to our standard turret, it's our only one atm.
    turretToBuild = standardTurretPrefab;
  }

  public GameObject getTurretToBuild()
  {
    return turretToBuild;
  }
}
