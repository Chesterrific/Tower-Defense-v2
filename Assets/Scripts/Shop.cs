using UnityEngine;

public class Shop : MonoBehaviour
{

  BuildManager buildManager;

  private void Start()
  {
    //Store buildManager instance for ease of use.
    buildManager = BuildManager.instance;
  }

  public void PurchaseStandardTurret()
  {
    Debug.Log("Standard Turret Selected");
    buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
  }

  public void PurchaseMissleTurret()
  {
    Debug.Log("Missle Turret Selected");
    buildManager.SetTurretToBuild(buildManager.missleTurretPrefab);
  }
}
