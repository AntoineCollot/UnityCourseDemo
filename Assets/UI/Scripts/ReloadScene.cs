using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour {

    bool reloading = false;

	public void Reload()
    {
        if (reloading)
            return;

        reloading = true;

        SceneManager.LoadScene(0);
    }
}
