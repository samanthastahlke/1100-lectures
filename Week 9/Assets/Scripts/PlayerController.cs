using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveForce;
    public float maxSpeed;

    private Rigidbody rb;
    private float sidewaysInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        sidewaysInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.AddForce(sidewaysInput * moveForce * Vector3.right);

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            Vector3 capped = rb.velocity;
            capped.x = (capped.x > 0) ? maxSpeed : -maxSpeed;
            rb.velocity = capped;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == PhysicsDemo.LAYER_DAMAGE)
        {
            other.enabled = false;
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
