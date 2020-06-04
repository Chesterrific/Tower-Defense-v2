using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
  private Enemy enemyStats;
  private Transform target;
  private int wavepointIndex = 0;

  void Start()
  {
    target = Waypoints.points[0];

    if (enemyStats == null)
    {
      enemyStats = GetComponent<Enemy>();
    }

  }

  void Update()
  {
    //This gives us direction pointing towards target. TARGET.position - YOUR POSITION will give proper heading.
    Vector3 dir = target.position - transform.position;

    //Normalizing the vector changes it's maginitude to 1, allowing us to control the speed of the object without changing its direction.
    transform.Translate(dir.normalized * enemyStats.speed * Time.deltaTime, Space.World);

    //This statement will run when our this object is within 0.5f of the waypoint.
    if (Vector3.Distance(transform.position, target.position) <= 0.5f) //Gives us the distance between two objects. (a-b) magnitude.
    {
      GetNextWaypoint();
    }

    enemyStats.speed = enemyStats.startSpeed;
  }

  void GetNextWaypoint()
  {

    //If no next wavepoint, destroy object.
    if (wavepointIndex >= Waypoints.points.Length - 1)
    {
      EndPath();
      return;
    }
    wavepointIndex++;
    target = Waypoints.points[wavepointIndex];
  }

  void EndPath()
  {
    Destroy(gameObject);
    PlayerStats.Lives--;
    return;
  }
}
