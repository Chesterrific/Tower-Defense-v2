using UnityEngine;
using UnityEngine.UI;

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

  /*------------------------------------------------------------------------------------------------------*/

  [Header("Build Manager Options")]
  public GameObject buildEffect;
  public NodeUI nodeUI;

  private TurretBlueprint turretToBuild;
  private Node selectedNode;

  //These are "properties", these variable can never be set manually. It is equvialent to writing a small function to check for true or false!
  public bool CanBuild { get { return turretToBuild != null; } }
  public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

  public void SelectTurretToBuild(TurretBlueprint turret)
  {
    turretToBuild = turret;
    DeselectNode();
  }

  public void SelectNode(Node node)
  {
    if (selectedNode == node)
    {
      DeselectNode();
      return;
    }

    selectedNode = node;
    turretToBuild = null;

    nodeUI.SetTarget(node);
  }

  public void DeselectNode()
  {
    selectedNode = null;
    nodeUI.Hide();
  }

  public TurretBlueprint GetTurretToBuild(){
    return turretToBuild;
  }
}
