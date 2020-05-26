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
  public GameObject missleTurretPrefab;

  private GameObject turretToBuild;

  public void SetTurretToBuild(GameObject turret)
  {
    turretToBuild = turret;
  }

  public GameObject GetTurretToBuild()
  {
    return turretToBuild;
  }
}
