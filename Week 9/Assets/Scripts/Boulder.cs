using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Boulder : MonoBehaviour
{
    public Collider damageZone;
    public AnimationClip breakAnim;
    public string breakTrigger = "break";
    private bool broken = false;

    public void Randomize()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(0.0f, 0.0f, Random.Range(-Mathf.PI, Mathf.PI));
        transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.Range(0.0f, Mathf.PI / 2.0f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == PhysicsDemo.LAYER_TERRAIN)
        {
            damageZone.enabled = false;
            BreakApart();
        }
    }

    private void BreakApart()
    {
        if (broken)
            return;

        broken = true;
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(breakTrigger);
        Invoke(nameof(Despawn), breakAnim.length);
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }
}
