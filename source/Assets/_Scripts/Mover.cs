using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speedMultiplier = 1f;
	public float strafeMultipler = 1f;

	void Start()
	{
		Debug.Log(transform.localScale);
	}

	void Update() 
	{
		transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * strafeMultipler);

		if(Input.GetButtonDown("TurnRight")) //E
		{
			this.transform.Rotate(Vector3.up * 90);
			//Debug.Log(this.transform.forward);

			// this.transform.RotateAround(new Vector3(0.0f, 1.0f, 0.0f), 78);
		}
		else if(Input.GetButtonDown("TurnLeft")) //Q
		{
			this.transform.Rotate(Vector3.up * -90);
		}

		transform.Translate(Vector3.forward*Time.deltaTime*speedMultiplier);

		// Debug.Log(transform.position.y + " z pos");
		if(transform.position.y < -1f)
		{
			this.GetComponent<Shrinker>().KillPlayer();
		}
	}
}
