using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public Transform minPos;
    public Transform maxPos;

    private bool movingUp = false;

    public float moveSpeed;
    public float minMoveTime;
    public float maxMoveTime;

    private float currentMoveTime;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        RandomizeTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= currentMoveTime)
        {
            movingUp = !movingUp;
            RandomizeTime();
        }

        Vector3 direction = (movingUp) ? Vector3.up : Vector3.down;
        transform.position += Time.deltaTime * moveSpeed * direction;

        Vector3 position = transform.position;

        if (position.y > maxPos.position.y)
            position.y = maxPos.position.y;
        else if (position.y < minPos.position.y)
            position.y = minPos.position.y;

        transform.position = position;

    }

    void RandomizeTime()
    {
        currentMoveTime = Random.Range(minMoveTime, maxMoveTime);
        timer = 0.0f;
    }
}
