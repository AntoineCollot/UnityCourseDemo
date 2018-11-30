using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour {

	public float speed;
	public float jumpForce;

    Rigidbody r;
    Vector3 inputVelocity;

    // Use this for initialization
    void Awake () {
        r = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        inputVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;

        if (Input.GetButtonDown("Jump"))
        {
            r.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }
    }
	
	void FixedUpdate()
	{
        inputVelocity.y = r.velocity.y;
        r.velocity = inputVelocity;
	}
}
