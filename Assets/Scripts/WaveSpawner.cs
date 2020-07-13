using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
  public static int EnemiesAlive = 0;

  public WaveWrap[] waves;
  public Transform spawnPoint;
  public Text waveCountDownText;
  public GameManager gameManager;
  public float timeBetweenWaves = 20f;
  public float countdown = 10f;

  public Text roundCounterUI;

  private int waveIndex = 0;
  private bool moneyGiven = true;

  private void Start()
  {
    EnemiesAlive = 0;
    roundCounterUI.text = PlayerStats.Rounds + "\n---\n" + waves.Length;
  }

  private void Update()
  {
    if (EnemiesAlive > 0)
    {
      return;
    }
    if (waveIndex == waves.Length && PlayerStats.Lives > 0)
    {
      Debug.Log("Level complete");
      gameManager.WinLevel();
      this.enabled = false;
    }
    if (GameManager.GameEnded)
    {
      this.enabled = false;
    }
    if (!moneyGiven)
    {
      PlayerStats.Money += waves[waveIndex - 1].waveWorth;
      moneyGiven = true;
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
    moneyGiven = false;
    roundCounterUI.text = PlayerStats.Rounds + "\n---\n" + waves.Length;

    Wave[] currentWave = waves[waveIndex].individualWaves;

    for (int i = 0; i < currentWave.Length; i++)
    {
      for (int j = 0; j < currentWave[i].count; j++)
      {
        SpawnEnemy(currentWave[i].enemy);

        yield return new WaitForSeconds(1f / currentWave[i].rate);
      }
    }
    waveIndex++;
  }

  void SpawnEnemy(GameObject enemy)
  {
    EnemiesAlive++;
    //creates object into game requires object, position (Vector3), and rotation.
    Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
  }

  public void ResetGame()
  {
    EnemiesAlive = 0;
  }
}
