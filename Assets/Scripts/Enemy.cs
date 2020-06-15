using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
  [Header("Enemy Characteristics")]

  public float startSpeed = 10f;
  public float starthealth;
  public int value = 50;
  public GameObject deathEffect;
  public Image healthBar;
  
  [HideInInspector]
  public float speed;
  private float health;

  private void Start() {
    health = starthealth;
    speed = startSpeed;
  }

  public void TakeDamage(float damage)
  {
    health -= damage;

    healthBar.fillAmount = health / starthealth;

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
