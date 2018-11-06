using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPhysic : MonoBehaviour {

    public Vector3 hitPoint;

    public float hitDistance;

    public float maxDistance;

    public LayerMask layer;
	
	// Update is called once per frame
	void Update () {
        //Create a ray starting at the transform position and going forward
        Ray ray = new Ray(transform.position, transform.forward);
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
