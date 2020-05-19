using UnityEngine;

public class Waypoints : MonoBehaviour
{
  //Accessible to other scripts.
  public static Transform[] points;


  //Awake vs Start to make sure that any other objects that need the "points" array can use it.
  // Order is as follows: Awake > Start > Updates.
  private void Awake()
  {
    //Allocate memory for array.
    points = new Transform[transform.childCount];

    //Loop through our waypoint holder object's children to populate array.
    for (int i = 0; i < points.Length; i++)
    {
      points[i] = transform.GetChild(i);
    }
  }

}