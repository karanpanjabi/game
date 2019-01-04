using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject instr;

	void Update()
	{
		if(Input.GetButton("Cancel") && instr.active)
		{
			instr.SetActive(false);
		}
	}

	public void StartGame()
	{
		SceneManager.LoadScene("ggjam");
	}

	public void StopGame()
	{
		Application.Quit();
	}

	public void ShowInstructions()
	{
		instr.SetActive(true);
	}

}
