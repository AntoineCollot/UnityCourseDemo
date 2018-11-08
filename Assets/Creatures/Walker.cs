using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ground.GroundType type = Ground.Instance.GetType(transform.position);

        print((type & Ground.GroundType.Land) == Ground.GroundType.Land);
    }
}
