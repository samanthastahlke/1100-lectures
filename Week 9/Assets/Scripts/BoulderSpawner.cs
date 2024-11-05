using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawner : MonoBehaviour
{
    public Boulder template;
    public BoxCollider spawnZone;
    public float minSpawnTime = 1.0f;
    public float maxSpawnTime = 2.0f;

    private float nextSpawnTime = 0.0f;
    private float timer = 0.0f;

    void Start()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= nextSpawnTime)
        {
            timer = 0.0f;
            nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            Vector3 min = spawnZone.bounds.min;
            Vector3 max = spawnZone.bounds.max;

            Vector3 pos = new Vector3(
                Random.Range(min.x, max.x),
                max.y, 
                0.0f);

            Boulder rock = Instantiate(template);
            rock.transform.position = pos;
            rock.Randomize();
        }
    }
}
