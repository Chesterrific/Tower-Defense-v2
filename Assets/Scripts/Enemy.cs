using UnityEngine;

public class Enemy : MonoBehaviour
{
  [Header("Enemy Characteristics")]

  public float startSpeed = 10f;
  public float health = 10;
  public int value = 50;
  public GameObject deathEffect;
  
  [HideInInspector]
  public float speed;

  private void Start() {
    speed = startSpeed;
  }

  public void TakeDamage(float damage)
  {
    health -= damage;
    if (health <= 0){
      Die();
    }
  }

  public void Slow(float slowAmount)
  {
    speed = startSpeed * (1f - slowAmount);
  }

  void Die(){
    PlayerStats.Money += value;
    GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);

    Destroy(effect, 5f);
    Destroy(gameObject);
  }
}
