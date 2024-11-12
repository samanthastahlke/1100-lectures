using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public int maxHealth;
    private int hp;

    public float sprintEnergyMax;
    public float sprintDrain;
    public float sprintRecover;
   
    private bool sprinting = false;
    private float sprintEnergy;

    public float moveForce;
    public float maxSpeed;
    public float sprintSpeed;

    private Rigidbody rb;
    private float sidewaysInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sprintEnergy = sprintEnergyMax;
        hp = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        sidewaysInput = Input.GetAxis("Horizontal");

        bool sprintKey = Input.GetKey(KeyCode.LeftShift);
        sprinting = sprintKey && sprintEnergy > 0.0f;

        if (sprinting)
            sprintEnergy -= sprintDrain * Time.deltaTime;
        else if (!sprintKey)
            sprintEnergy += sprintRecover * Time.deltaTime;

        sprintEnergy = Mathf.Clamp(sprintEnergy, 0.0f, sprintEnergyMax);
    }

    private void FixedUpdate()
    {
        rb.AddForce(sidewaysInput * moveForce * Vector3.right);
        
        float cappedSpeed = sprinting ? sprintSpeed : maxSpeed;

        if (Mathf.Abs(rb.velocity.x) > cappedSpeed)
        {
            Vector3 capped = rb.velocity;
            capped.x = (capped.x > 0) ? cappedSpeed : -cappedSpeed;
            rb.velocity = capped;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == PhysicsDemo.LAYER_DAMAGE)
        {
            other.enabled = false;
            --hp;

            if(hp == 0)
            {
                Debug.Log("Game Over!");
                gameObject.SetActive(false);
            }    
        }
    }

    public int GetHP()
    {
        return hp;
    }

    public float GetEnergyProportion()
    {
        return sprintEnergy / sprintEnergyMax;
    }
}
