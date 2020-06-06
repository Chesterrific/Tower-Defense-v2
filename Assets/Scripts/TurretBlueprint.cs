using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We need to include this line if we want this class to appear in the inspector.
[System.Serializable]

//MonoBehavior means we want to attach this script to soemthing. We removed it because we aren't attaching this script to anything. It's just a class we can initialize.
public class TurretBlueprint
{
  public GameObject prefab;
  public int cost;
  public int sellCost;

  public GameObject upgradePrefab;
  public int upgradeCost;
  public int upgradeSellCost;
}
