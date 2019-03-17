using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour {

    public int openingHour;
    public int closingHour;

    public GameObject openedSign;
    public GameObject closedSign;

    public GameObject[] products;

    // Use this for initialization
    void Start () {
        Clock.Instance.hourChanged.AddListener(OnNewHour);
	}
	
	public void OnNewHour(int hour)
    {
        bool shopIsOpen = hour >= openingHour && hour < closingHour;

        openedSign.SetActive(shopIsOpen);
        closedSign.SetActive(!shopIsOpen);

        foreach(GameObject g in products)
        {
            g.SetActive(shopIsOpen);
        }
    }
}
