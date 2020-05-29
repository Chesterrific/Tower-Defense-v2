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
  public GameObject buildEffect;

  private TurretBlueprint turretToBuild;

  //These are "properties", these variable can never be set manually. It is equvialent to writing a small function to check for true or false!
  public bool CanBuild { get { return turretToBuild != null; } }
  public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

  public void SelectTurretToBuild(TurretBlueprint turret)
  {
    turretToBuild = turret;
  }

  //Instantiate turret on given node, with a given position, with no rotation (Quaternion.identity = no rotation).
  //Store built turret into given node's own turret vairable.
  public void BuildTurretOn(Node node)
  {
    if (PlayerStats.money < turretToBuild.cost)
    {
      Debug.Log("Not enough $$");
      return;
    }

    PlayerStats.money -= turretToBuild.cost;
    Debug.Log("Turret built, money left: " + PlayerStats.money);

    GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
    node.turret = turret;

    GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
    Destroy(effect, 5f);
  }
}
