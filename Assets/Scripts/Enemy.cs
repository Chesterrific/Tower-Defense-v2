using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
  [Header("Enemy Characteristics")]

  public float startSpeed = 10f;
  public float starthealth;
  // public int value = 50;
  public int damage = 1;
  public GameObject deathEffect;
  public Image healthBar;

  [Header("Baby Charactersitics")]
  public bool spawnEnemy = false;
  public GameObject baby;

  [HideInInspector]
  public float speed;
  private float health;
  private bool isDead = false;
  private EnemyMovement currentMove;

  private void Start()
  {
    health = starthealth;
    speed = startSpeed;
    currentMove = GetComponent<EnemyMovement>();
  }

  public void TakeDamage(float damage)
  {
    health -= damage;

    healthBar.fillAmount = health / starthealth;

    if (health <= 0 && !isDead)
    {
      Die();
    }
  }

  public void Slow(float slowAmount)
  {
    speed = startSpeed * (1f - slowAmount);
  }

  void Die()
  {
    isDead = true;
    // PlayerStats.Money += value;

    GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
    Destroy(effect, 5f);

    if (spawnEnemy)
    {
      SpawnBaby();
    }

    WaveSpawner.EnemiesAlive--;
    Destroy(gameObject);
  }

  void SpawnBaby()
  {
    GameObject newEnemy = (GameObject)Instantiate(baby, transform.position, Quaternion.identity);
    EnemyMovement newEnemyMovement = newEnemy.GetComponent<EnemyMovement>();

    newEnemyMovement.SetTarget(currentMove.GetTarget());
    newEnemyMovement.SetWavePointIndex(currentMove.GetWavePointIndex());
    WaveSpawner.EnemiesAlive++;
  }
}
