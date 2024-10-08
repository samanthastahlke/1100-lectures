using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy is inheriting from Unity's Component type "MonoBehaviour"
public class Enemy : MonoBehaviour
{
    // The speed at which this enemy will move.
    public float moveSpeed;
    // The amount of time the enemy has before it is removed from play.
    public float lifetimeSeconds;

    private Vector3 direction = new Vector3();
    private float timerSeconds;

    // Start is called before the first frame update
    void Start()
    {
        // Pick a random angle to move in.
        float angle = Random.Range(0.0f, 2.0f * Mathf.PI);

        // Create a direction vector from that angle.
        direction.x = Mathf.Cos(angle);
        direction.y = Mathf.Sin(angle);
    }

    // Update is called once per frame
    void Update()
    {
        // Step the position towards the move direction by
        // adding the movement direction vector to our position.
        transform.position += Time.deltaTime * moveSpeed * direction;

        // Accumulate the time that has passed into our timer counter.
        timerSeconds += Time.deltaTime;

        // Have we lived beyond the set amount?
        if (timerSeconds > lifetimeSeconds)
        {
            // If so, we can have our gameobject destroyed.
            Destroy(gameObject);
        }
    }
}
