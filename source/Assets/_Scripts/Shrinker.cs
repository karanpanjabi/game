using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Shrinker : MonoBehaviour {


	public float ballDecreaseRate = 0.01f;
	public float haloDecreaseRate = 0.01f;

	public GameObject energyOb;
	public Light lightHalo;

	public GameObject DieEffect;

	public GameObject TimerText;

	public GameObject audio;

	public bool gameOn;

	void Start()
	{
		gameOn = true;
	}

	void Update()
	{
		if(Input.GetButtonDown("Cancel") && !gameOn)
		{
			SceneManager.LoadScene("MainMenu");
		}
	}
	// Update is called once per frame
	public void Shrink(float energyPoints)
	{
		float ep = energyOb.GetComponent<EnergyStuff>().energyPoints;
		// transform.localScale( -= ballDecreaseRate * new Vector3(1,1,1);
		transform.localScale = (ep/50.0f) * new Vector3(1,1,1);

		if(transform.localScale.magnitude <= 0)
		{	
			transform.localScale = new Vector3(0,0,0);
		}

		// lightHalo.areaSize -= haloDecreaseRate * new Vector2(1,1);
		// lightHalo.areaSize = (ep/50.0f) * new Vector2(1,1);
		lightHalo.range = (ep*1.8f)/50f;

		
	}

	public void KillPlayer()
	{
		audio.GetComponent<AudioSource>().Play();
		gameObject.active = false;
		Instantiate(DieEffect, transform.position, transform.rotation);
		TimerText.GetComponent<Timer>().StopTimer();

		gameOn = false;
	}
}
