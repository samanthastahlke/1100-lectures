using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBar : MonoBehaviour
{
    public EnergyBar energyBar;

    public float fishForce = 10.0f;

    private bool mouseHeld = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseHeld = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        if(mouseHeld)
        {
            rb.AddForce(fishForce * Vector3.up);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fish"))
        {
            energyBar.FishEnteredBar();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("fish"))
        {
            energyBar.FishExitedBar();
        }
    }
}
