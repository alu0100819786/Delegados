using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEsfera : MonoBehaviour
{

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * 1f, ForceMode.Impulse);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * 1f, ForceMode.Impulse);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * 1f, ForceMode.Impulse);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * 1f, ForceMode.Impulse);
            
        }
    }
}
