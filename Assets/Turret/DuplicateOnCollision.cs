using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Create a clone of the object the first time it collides with something. The clone cannot duplicate.
/// </summary>
public class DuplicateOnCollision : MonoBehaviour {

    public float duplicateBallSpeed = 1;
    bool duplicateOnCollision = true;

    /// <summary>
    /// Called automatically by the rigidbody, if any, when it enters in collision with another object with a collider 
    /// </summary>
    /// <param name="collision">Collision data populated by the rigidbody</param>
    private void OnCollisionEnter(Collision collision)
    {
        //Check if the object should duplicate or not on collision, if not, stops here.
        if (!duplicateOnCollision)
            return;

        //Create a copy of our ball
        DuplicateOnCollision duplicateBall = Instantiate(this, transform.position, transform.rotation, null);

        //Give it a random rotation
        duplicateBall.transform.rotation = Random.rotation;

        //Makes it go in the direction it is facing
        duplicateBall.GetComponent<Rigidbody>().velocity = duplicateBall.transform.forward * duplicateBallSpeed;

        //Make the copy do not spawn ball on collision
        duplicateBall.SetDuplicateOnCollision(false);

        //Make itself stop spawning balls
        duplicateOnCollision = false;
    }

    public void SetDuplicateOnCollision(bool value)
    {
        duplicateOnCollision = value;
    }
}
