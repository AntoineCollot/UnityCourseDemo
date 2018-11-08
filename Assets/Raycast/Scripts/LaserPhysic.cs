using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPhysic : MonoBehaviour {

    public Vector3 hitPoint;

    public float hitDistance;

    public float maxDistance;

    public LayerMask layer;

    public bool aimAtCursor;

    Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {

        //The ray to send through the scene
        Ray ray;
        if(aimAtCursor)
        {
            //Get the cursor position in the scene
            Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit cursorHit;
            if (Physics.Raycast(camRay, out cursorHit, 50, layer))
            {
                //Makes a ray start at the transform and aim at cursor position
                ray = new Ray(transform.position, cursorHit.point - transform.position);
            }
            else
            {
                //If the cursor doesn't hit anything, makes the ray start at the transform position and go forward
                ray = new Ray(transform.position, transform.forward);
            }
        }
        else
        {
            //Makes the ray start at the transform position and go forward
            ray = new Ray(transform.position, transform.forward);
        }
        
        RaycastHit hit;

        //Send a raycast along the ray
        if (Physics.Raycast(ray, out hit, maxDistance, layer))
        {
            hitDistance = hit.distance;
            hitPoint = hit.point;
        }
        else
        {
            //If the raycast doesn't hit anything, manually place the hitpoint to the maximum distance forward
            hitDistance = maxDistance;
            hitPoint = transform.position + transform.forward * maxDistance;
        }

    }
}
