using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayHealth : MonoBehaviour {

    public Image healthbarFillingImage;
	
	// Update is called once per frame
	void LateUpdate () {
        healthbarFillingImage.fillAmount = RunAndJumpGameManager.Instance.Health;
    }
}
