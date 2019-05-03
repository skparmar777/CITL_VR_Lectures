using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPointer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            Vector3 reset_pos = new Vector3(231.935f, 8.337f, 271.297f);
            transform.position = reset_pos;
            Rigidbody pointer = GetComponent<Rigidbody>();
            Vector3 vel = new Vector3(0, 0, 0);
            pointer.velocity = vel;
        }
    }
}
