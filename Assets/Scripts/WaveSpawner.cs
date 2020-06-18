using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
  public static int EnemiesAlive = 0;

  public Wave[] waves;
  public Transform spawnPoint;
  public Text waveCountDownText;
  public GameManager gameManager;

  public float timeBetweenWaves = 20f;
  private float countdown = 2f;
  private int waveIndex = 0;

  private void Start()
  {
    EnemiesAlive = 0;
    Debug.Log(waves.Length);
  }

  private void Update()
  {
    if (EnemiesAlive > 0)
    {
      return;
    }
    if (waveIndex == waves.Length)
    {
      Debug.Log("Level complete");
      gameManager.WinLevel();
      this.enabled = false;
    }
    if (countdown <= 0f)
    {
      //Coroutines are called using this command.
      StartCoroutine(SpawnWave());
      countdown = timeBetweenWaves;
      return;
    }
    //Time.deltatime is the time since drawing the last frame, i.e. 1 second if game runs at 60fps.
    countdown -= Time.deltaTime;

    countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

    waveCountDownText.text = string.Format("{0:00.00}", countdown);
  }

  //Coroutine, can be paused by yield command. Needs System.collections namespace.
  IEnumerator SpawnWave()
  {
    PlayerStats.Rounds++;

    Wave wave = waves[waveIndex];

    EnemiesAlive = wave.count;

    for (int i = 0; i < wave.count; i++)
    {
      SpawnEnemy(wave.enemy);

      //Note that yield return is just for waiting, yield break exits the coroutine.
      yield return new WaitForSeconds(1f / wave.rate);
    }
    waveIndex++;
  }

  void SpawnEnemy(GameObject enemy)
  {
    //creates object into game requires object, position (Vector3), and rotation.
    Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
  }

  public void ResetGame()
  {
    EnemiesAlive = 0;
  }
}
