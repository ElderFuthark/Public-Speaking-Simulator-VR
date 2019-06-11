using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class timer : MonoBehaviour {

	public float totalTime;
	public TextMeshProUGUI clockText;
	public Button pauseButton;
	public Image buttonImg;						// Button background image that's altered to change the color.
	public Material[] colorMaterials;
	public bool paused;
	// Use this for initialization
	void Start () {
		totalTime = 60f * 5f;		// 5 minutes in seconds
		paused = true;
		buttonImg = GameObject.Find("Start and Pause").GetComponent<Image>();			// Grab the start and pause button's image
		clockText = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();			// Grab the text mesh pro GUI component
		Debug.Log(clockText.name);
		StartCoroutine(changeColor());
	}
	public IEnumerator changeColor()			// Checks of the timer is paused. The button's color is changed and then the thread is put to sleep until paused changes.
	{
		if(paused == true)
		{
			buttonImg.color = Color.red;
			//GameObject.Find("Start and Pause").GetComponent<Text>().text = "Start";
			yield return new WaitUntil(() => paused == false);
		}
		if(paused == false)
		{
			buttonImg.color = Color.green;
			//GameObject.Find("Start and Pause").GetComponent<Text>().text = "Pause";
			yield return new WaitUntil(() => paused == true);
		}
		yield return new WaitForSeconds(1/90);
	}
	// Update is called once per frame
	void Update () {
		// On each frame, update the clock text with the current
		if(paused == false)
			totalTime -= Time.deltaTime;			// Total time minus the time since the last Time.deltaTime
		if(totalTime < 0)						// If totalTime is less than 0 do something.
		{
			Debug.Log("Game Over");
			enabled = false;
		}
		int seconds = (int)(totalTime % 60);				// seconds conversion
		int minute = (int)((totalTime/60) % 60);			// minutes conversion
		int hour = (int)((totalTime/3600) % 60);			// hours conversion

		clockText.text = hour.ToString() + ":" + minute.ToString() + ":" + seconds.ToString();			// Change clock text.
	}

	// setter for paused boolean
	public void setPaused()
	{
		Debug.Log(paused);
		if(paused == true)
			paused = false;
		else
			paused = true;
			Debug.Log(paused);
	}
}
