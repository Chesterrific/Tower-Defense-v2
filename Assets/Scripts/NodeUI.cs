using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
  public GameObject ui;
  public Text upgradeText;
  public Text sellText;

  public Button upgradeButton;
  public Button sellButton;

  private Node target;

  private void SetPrices()
  {
    if (!target.isUpgraded)
    {
      upgradeText.text = "UPGRADE\n$" + target.turretBlueprint.upgradeCost;
      upgradeButton.interactable = true;

      sellText.text = "SELL\n$" + target.turretBlueprint.sellCost;
    }
    else
    {
      upgradeText.text = "MAX LVL";
      upgradeButton.interactable = false;
      
      sellText.text = "SELL\n$" + target.turretBlueprint.upgradeSellCost;
    }
  }

  public void SetTarget(Node node)
  {
    target = node;

    transform.position = target.GetBuildPosition();

    SetPrices();
    ui.SetActive(true);
  }

  public void Hide()
  {
    ui.SetActive(false);
  }

  public void Upgrade()
  {
    if (target.isUpgraded)
    {
      Debug.Log("Turret on node has already been upgraded.");
      BuildManager.instance.DeselectNode();
      return;
    }
    target.UpgradeTurret();
    BuildManager.instance.DeselectNode();
  }
}
