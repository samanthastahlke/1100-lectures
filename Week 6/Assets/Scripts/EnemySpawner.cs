using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // The list of posible options to spawn.
    public List<GameObject> EnemiesToSpawn;
    // The amount of time to wait between enemy spawns.
    public float frequencySeconds = 2.0f;

    // The current elapsed time since the last spawn.
    private float timerSeconds;

    // Update is called once per frame
    void Update()
    {
        // Accumulate the time that has passed into our timer counter.
        timerSeconds += Time.deltaTime;

        // Have we waited long enough to spawn another enemy?
        if (timerSeconds > frequencySeconds)
        {
            // Pick a random index in the list of possible enemy prefabs to spawn.
            int index = Random.Range(0, EnemiesToSpawn.Count);

            // Spawn it!
            GameObject newEnemy = Instantiate(EnemiesToSpawn[index]);
            // Make sure it has the correct position, at this spawner position.
            newEnemy.transform.position = this.transform.position;

            // Reset our timer, so that we will wait until the next spawn.
            timerSeconds = 0.0f;
        }
    }
}
