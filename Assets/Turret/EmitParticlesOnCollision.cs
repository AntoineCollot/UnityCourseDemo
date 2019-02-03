using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitParticlesOnCollision : MonoBehaviour {

    public GameObject particlesPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        //Spawn a particle effect at its position
        GameObject newParticles = Instantiate(particlesPrefab, transform.position, Quaternion.identity, null);
        //Destroy the particles in 1 sec
        Destroy(newParticles, 1);

        //Destroy itself
        Destroy(gameObject);

    }
}
