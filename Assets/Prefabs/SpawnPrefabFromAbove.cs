using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabFromAbove : MonoBehaviour {

    public KeyCode spawnKey;
    public Transform prefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(spawnKey))
		{
            Spawn();
        }
    }
	
	void Spawn()
	{
        Ray downwardRay = new Ray(transform.position + Vector3.up * 10f, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(downwardRay, out hit, Mathf.Infinity))
        {
            //The spawn position is the point hit by the ray
            Vector3 spawnPosition = hit.point;
            //Move the spawn position by O,5 upward so the prefab is above the ground (instead of being in the ground)
            spawnPosition += Vector3.up * 0.5f;
            SnapPositionToGrid(ref spawnPosition);
            //The spawn rotation is 0 (no rotation)
            Quaternion spawnRotation = Quaternion.identity;
            //The parent is the object hit by the ray
            Transform parent = hit.transform;
            Instantiate(prefab, spawnPosition, spawnRotation, parent);
        }
	}
	
	void SnapPositionToGrid(ref Vector3 pos)
	{
        pos.x = Mathf.Round(pos.x);
        pos.z = Mathf.Round(pos.z);
    }
}
