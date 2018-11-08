using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public static Ground Instance;

    public Texture2D groundTypeTexture;
    public Vector2 areaSize;

    [System.Flags]
    public enum GroundType {
        None = 0,
        Land =1<<0,
        Water = 1<<1,
        Forest = 1<<2,
        All = 0xFFFF
    }

	// Use this for initialization
	void Awake () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GroundType GetType(Vector3 position)
    {
        //Get the pixel corresponding to the position (if between two pixels, GetPixelBilinear returns something in between the two values)
        Color colorAtPosition = groundTypeTexture.GetPixelBilinear(position.x / areaSize.x, position.z / areaSize.y);

        GroundType type = GroundType.None;

        //Red is for land
        if (colorAtPosition.r > 0)
            type |= GroundType.Land;
        //Blue is for water
        if (colorAtPosition.b > 0)
            type |= GroundType.Water;
        //Green is for forest
        if (colorAtPosition.g > 0)
            type |= GroundType.Forest;

        return type;
    }
}
