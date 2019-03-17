using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusDriveAcrossScreen : MonoBehaviour {

    public int[] driveHours;

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

        Clock.Instance.hourChanged.AddListener(OnNewHour);
	}
	
	void OnNewHour(int hour)
    {
        foreach(int h in driveHours)
        {
            if(h==hour)
                anim.SetTrigger("Drive");
        }
    }
}
