using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerFollower : MonoBehaviour {

	public GameObject player;
	public float smoothFactor = 1.0f;
	Vector3 positionOffset;
	Quaternion targetRot;

	// Use this for initialization
	void Start () {
		positionOffset = this.transform.position - player.transform.position;

		targetRot = transform.rotation;
	}
	
	void Update()
	{
		if(Input.GetButtonDown("Cancel") && !player.GetComponent<Shrinker>().gameOn)
		{
			SceneManager.LoadScene("MainMenu");
		}
	}

	// Update is called once per frame
	void LateUpdate () {
		this.transform.position = positionOffset + player.transform.position;

		if(Input.GetButtonDown("TurnRight")) //E
		{
			targetRot = transform.rotation * Quaternion.Euler(0, 90, 0);
		}
		else if(Input.GetButtonDown("TurnLeft")) //Q
		{
			targetRot = transform.rotation * Quaternion.Euler(0, -90, 0);
		}


		transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * smoothFactor);
	}

}
