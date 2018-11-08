using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPyramideInConsole : MonoBehaviour {

    public int lineCount;

	// Use this for initialization
	void Start () {
        int starToDraw = 1;
        int characterPerLine = 1 + lineCount * 2;
        string pyramide = "";
        for (int i = 0; i < lineCount; i++)
        {
            string line = "";
            int spaceToDraw = characterPerLine - starToDraw;
            for (int s = 0; s < spaceToDraw/2; s++)
            {
                line += " ";
            }
            for (int s = 0; s < starToDraw; s++)
            {
                line += "*";
            }
            for (int s = 0; s < spaceToDraw / 2; s++)
            {
                line += " ";
            }
            starToDraw += 2;
            pyramide += line + "\n";
        }
        Debug.Log(pyramide);
	}
}
