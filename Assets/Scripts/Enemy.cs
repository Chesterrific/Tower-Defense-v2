using UnityEngine;

public class Enemy : MonoBehaviour
{
  [Header("Enemy Characteristics")]
  public float speed = 10f;
  public int health = 10;
  public int value = 50;
  public GameObject deathEffect;

  private Transform target;
  private int wavepointIndex = 0;

  void Start()
  {
    target = Waypoints.points[0];
  }

  void Update()
  {
    //This gives us direction pointing towards target. TARGET.position - YOUR POSITION will give proper heading.
    Vector3 dir = target.position - transform.position;

    //Normalizing the vector changes it's maginitude to 1, allowing us to control the speed of the object without changing its direction.
    transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

    //This statement will run when our this object is within 0.5f of the waypoint.
    if (Vector3.Distance(transform.position, target.position) <= 0.5f) //Gives us the distance between two objects. (a-b) magnitude.
    {
      GetNextWaypoint();
    }
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

  public void TakeDamage(int damage)
  {
    health -= damage;
    if (health <= 0){
      Die();
    }
  }

  void Die(){
    PlayerStats.Money += value;
    GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);

    Destroy(effect, 5f);
    Destroy(gameObject);
  }
}
