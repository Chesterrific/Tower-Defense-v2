using UnityEngine;

public class Shop : MonoBehaviour
{
  public TurretBlueprint standardTurret;
  public TurretBlueprint missleTurret;

  BuildManager buildManager;

  private void Start()
  {
    //Store buildManager instance for ease of use.
    buildManager = BuildManager.instance;
  }

  public void SelectStandardTurret()
  {
    Debug.Log("Standard Turret Selected");
    buildManager.SelectTurretToBuild(standardTurret);
  }

  public void SelectMissleTurret()
  {
    Debug.Log("Missle Turret Selected");
    buildManager.SelectTurretToBuild(missleTurret);
  }
}
