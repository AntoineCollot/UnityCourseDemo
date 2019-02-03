using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBalls : MonoBehaviour {

    public Rigidbody ballPrefab;

    public float speed = 15;
	
	// Update is called once per frame
	void Update () {
        //Envoi une balle quand on appuis sur espace
		if(Input.GetKeyDown(KeyCode.Space))
        {
            ThrowBall();
        }
	}

    public void ThrowBall()
    {
        //Instancie une nouvelle balle à partir du prefab
        //On lui donne la position de notre transform, et on garde sa rotation. On ne lui donne pas de parent, elle seront donc à la racine de la scène
        Rigidbody newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity, null);

        //Paramètre la vitesse de départ de la balle.
        //On lui donne comme direction la direction de notre transform et comme vitesse notre paramètre publique.
        newBall.velocity = transform.forward * speed;
    }
}
