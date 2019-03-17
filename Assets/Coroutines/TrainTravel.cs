using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTravel : MonoBehaviour {

    public Transform station0;
    public Transform station1;
    public float travelTime;
    public float pauseTime;

	// Use this for initialization
	void Start () {
        StartCoroutine(TravelInfinite());
	}

    /// <summary>
    /// Makes the train travel from 0 to 1, then back to 0 from 1 forever
    /// </summary>
    /// <returns></returns>
    IEnumerator TravelInfinite()
    {
        while(true)
        {
            yield return StartCoroutine(Travel(station0, station1, travelTime));
            yield return new WaitForSeconds(pauseTime);
            yield return StartCoroutine(Travel(station1, station0, travelTime));
            yield return new WaitForSeconds(pauseTime);
        }
    }

    /// <summary>
    /// Coroutine that handles the travel from a transform to another in a give time
    /// </summary>
    /// <param name="from">start position</param>
    /// <param name="to">target position</param>
    /// <param name="time">time it takes to go from start to target</param>
    /// <returns></returns>
    IEnumerator Travel(Transform from, Transform to, float time)
    {
        float t = 0;
        while(t<1)
        {
            t += Time.deltaTime / time;

            transform.position = Vector3.Lerp(from.position, to.position, t);

            yield return null;
        }
    }
}
