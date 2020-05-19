using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
  public Transform enemyPrefab;
  public Transform spawnPoint;
  public Text waveCountDownText;

  public float timeBetweenWaves = 5f;
  private float countdown = 2f;
  private int waveIndex = 0;

  private void Update()
  {
    if (countdown <= 0f)
    {
      //Coroutines are called using this command.
      StartCoroutine(SpawnWave());
      countdown = timeBetweenWaves;
    }
    //Time.deltatime is the time since drawing the last frame, i.e. 1 second if game runs at 60fps.
    countdown -= Time.deltaTime;

    //Change text in our UI element into our "countdown" variable timer. Round the "countdown" into integers which we then stringfy to pass as string.
    waveCountDownText.text = Mathf.Round(countdown).ToString();
  }

  //Coroutine, can be paused by yield command. Needs System.collections namespace.
  IEnumerator SpawnWave()
  {
    waveIndex++;

    for (int i = 0; i < waveIndex; i++)
    {
      SpawnEnemy();
      yield return new WaitForSeconds(0.5f);
    }
  }

  void SpawnEnemy()
  {
    //creates object into game requires object, position (Vector3), and rotation.
    Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
  }
}
