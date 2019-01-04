using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


	float elapsedTime;
	bool gameOn;
	// Use this for initialization
	void Start () {
		elapsedTime = 0;
		gameOn = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameOn)
		{
			elapsedTime += Time.deltaTime;
			this.GetComponent<Text>().text = "Time: "+elapsedTime;
		}
	}

	public void StopTimer()
	{
		gameOn = false;
	}
}
