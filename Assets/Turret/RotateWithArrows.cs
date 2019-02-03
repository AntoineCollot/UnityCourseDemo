using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithArrows : MonoBehaviour {

    public float speed;
    public Vector3 axis;
	
	// Update is called once per frame
	void Update () {
        //Récupère les inputs de l'utilisateur (entre -1 et 1) sur les flèches directionnels (si elles sont bien configurées dans l'InputManager)
        float arrowsInput = Input.GetAxis("Horizontal");

        //On obtient la vitesse de rotation en multipliant notre input (0 si aucun input) par la vitesse max puis on multiplie le tout par deltaTime pour être indépendant du framerate
        float resultingSpeed = speed * Time.deltaTime * arrowsInput;

        //Pivote le transform selon l'axe donné par la vitesse obtenue.
        transform.Rotate(axis * resultingSpeed);
	}
}
