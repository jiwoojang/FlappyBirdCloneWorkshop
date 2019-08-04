using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;

    [SerializeField]
    private float timeBetweenPipes = 2.0f;

    [SerializeField]
    private float spawnRangeUnits = 2.0f;

    public void StartSpawningPipes() {
        StartCoroutine("SpawnPipes");
    }

    private void SpawnPipe() {
        // Pick a random spot
        float randomYOffset = Random.Range(-spawnRangeUnits, spawnRangeUnits);

        // Make a new pipe
        Instantiate(pipePrefab, transform.position + new Vector3(0, randomYOffset, 0), Quaternion.identity);
    }

    private IEnumerator SpawnPipes() {
        while (GameController.instance.isPlaying) {
            SpawnPipe();

            yield return new WaitForSeconds(timeBetweenPipes);
        }
    }
}
