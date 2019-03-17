using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour {

    public int nightHour;
    public int dayHour;
    public float transitionTime;
    public Image nightBackground;

	// Use this for initialization
	void Start () {
        Clock.Instance.hourChanged.AddListener(OnNewHour);

        nightBackground.color = Color.white;
	}
	
	void OnNewHour(int hour)
    {
        if(hour==dayHour)
        {
            StartCoroutine(FadeColor(1, 0, transitionTime));
        }
        else if(hour==nightHour)
        {
            StartCoroutine(FadeColor(0, 1, transitionTime));
        }
    }


    IEnumerator FadeColor(float start, float target,float time)
    {
        float t = 0;

        while(t<1)
        {
            t += Time.deltaTime / time;

            Color color = nightBackground.color;
            color.a = Mathf.Lerp(start, target, t);
            nightBackground.color = color;

            yield return null;
        }
    }
}
