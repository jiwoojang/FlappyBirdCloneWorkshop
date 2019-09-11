using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float timeBetweenPipes = 2.0f;
    public float spawnRangeUnits = 2.0f;

    private void SpawnPipe() {
        // Pick a random spot
        float randomYOffset = Random.Range(-spawnRangeUnits, spawnRangeUnits);

        // Make a new pipe
        Instantiate(pipePrefab, transform.position + new Vector3(0, randomYOffset, 0), Quaternion.identity);
    }

    private IEnumerator SpawnPipes() {
        // Runs as long as the time in game is running
        while(true) {
            SpawnPipe();

            // Note that WaitForSeconds is affected by Time.Timescale
            yield return new WaitForSeconds(timeBetweenPipes);
        }
    }

    public void StartSpawningPipes() {
        // External interface to start spawning pipes
        StartCoroutine("SpawnPipes");
    }
}
