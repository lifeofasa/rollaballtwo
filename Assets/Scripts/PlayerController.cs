using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float jumpStrength;
    bool one;
    bool two;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        one = false;
        two = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpStrength);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("a"))
        {
            rb.useGravity = false;
            rb.AddForce(Vector3.up * 500f);
        }

        if (other.gameObject.CompareTag("pickup"))
        {
            if (one == false && two == false)
            {
                one = true;
            }
            else if (one == true && two == false)
            {
                two = true;
            }
            Destroy(other.gameObject);
        }
    }

    private void OnGUI()
    {
        if (one == false)
        {
            GUI.Label(new Rect(0, 0, 200f, 20f), "Pick-ups remaining: 2");
        }
        else if (one && !two)
        {
            GUI.Label(new Rect(0, 0, 200f, 20f), "Pick-ups remaining: 1");
        }
        else if (one && two)
        {
            GUI.Label(new Rect(0, 0, 200f, 20f), "go to goal!");

        }
    }
}
