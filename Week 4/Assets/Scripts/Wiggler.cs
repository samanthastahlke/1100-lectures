using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggler : MonoBehaviour
{
    public float wiggleYAmt;
    public float wiggleTime;

    private Vector3 posStart;
    private Vector3 posEnd;

    private float wiggleTimer = 0.0f;
    private bool forwards = true;

    // Start is called before the first frame update
    void Start()
    {
        posStart = transform.position;
        posEnd = posStart + new Vector3(0.0f, wiggleYAmt, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        wiggleTimer += Time.deltaTime;

        Vector3 p1 = (forwards) ? posStart : posEnd;
        Vector3 p2 = (forwards) ? posEnd : posStart;

        float t = Mathf.Clamp(wiggleTimer / wiggleTime, 0.0f, 1.0f);
        transform.position = Vector3.Lerp(p1, p2, t);

        if (wiggleTimer >= wiggleTime)
        {
            wiggleTimer = 0.0f;
            forwards = !forwards;
        }
    }
}
