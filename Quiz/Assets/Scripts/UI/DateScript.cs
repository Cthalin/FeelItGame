using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateScript : MonoBehaviour {

    [SerializeField]
    private Text timeText;
	
	// Update is called once per frame
	void Update () {
        System.DateTime now = System.DateTime.Now;
        var culture = new System.Globalization.CultureInfo("de-DE");
        timeText.text = now.ToString("dddd, dd MMMM yyyy - HH:mm",culture);
    }
}
