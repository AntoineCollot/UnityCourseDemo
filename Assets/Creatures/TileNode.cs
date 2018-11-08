using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNode : MonoBehaviour
{
    public TileType tileTypeMask = 0;

    public enum TileType
    {
        Normal = 1,
        Air = 2,
        Water = 4,
        Wall = 8,
        //etc    = 16,
        //etc    = 32,
    }
}