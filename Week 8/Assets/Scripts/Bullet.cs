using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 direction = Vector3.zero;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void Fire(Vector3 origin, Vector3 destination)
    {
        transform.position = origin;
        direction = destination - origin;
    }

    //For demo purposes, this is a simple way to destroy our bullet
    //as soon as it's no longer visible to the camera while the game
    //is running.
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
