using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour {

	public float speed;
	public float jumpForce;
    public float turnSpeed;

    Rigidbody r;
    Vector3 inputs;

    // Use this for initialization
    void Awake () {
        r = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        inputs = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetButtonDown("Jump"))
        {
            r.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }
    }
	
	void FixedUpdate()
	{
        Vector3 newVelocity = transform.forward * inputs.z * speed;
        
        newVelocity.y = r.velocity.y;
        r.velocity = newVelocity;
        r.angularVelocity = Vector3.up * inputs.x* turnSpeed;
	}
}
