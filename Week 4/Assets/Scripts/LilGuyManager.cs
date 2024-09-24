using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilGuyManager : MonoBehaviour
{
    public List<GameObject> lilGuys;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < lilGuys.Count; ++i)
            {
                Wiggler w = lilGuys[i].GetComponent<Wiggler>();

                if (w != null)
                    w.enabled = !w.enabled;
            }
        }
    }
}
