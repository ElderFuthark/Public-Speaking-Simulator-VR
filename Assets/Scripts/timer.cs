using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class timer : MonoBehaviour {

	public float totalTime;
	public TextMeshProUGUI clockText;
	// Use this for initialization
	void Start () {
		totalTime = 60f * 60f;		// 5 minutes in seconds
		totalTime += 15f;
		clockText = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
		Debug.Log(clockText.name);
	}
	
	// Update is called once per frame
	void Update () {
		// On each frame, update the clock text with the current
		totalTime -= Time.deltaTime;
		if(totalTime < 0)
		{
			Debug.Log("Game Over");
		}
		int seconds = (int)(totalTime % 60);
		int minute = (int)((totalTime/60) % 60);
		int hour = (int)((totalTime/3600) % 60);

		clockText.text = hour.ToString() + ":" + minute.ToString() + ":" + seconds.ToString();
	}
}
