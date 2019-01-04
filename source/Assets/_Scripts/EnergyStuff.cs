using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class EnergyDecreaseEvent : UnityEvent<float>
{
	
}

public class EnergyStuff : MonoBehaviour {

	public float energyPoints = 50f;
	public float decreaseRate = 0.5f;

	public EnergyDecreaseEvent eDecreaseEvent;
	public UnityEvent playerKillEvent;

	public GameObject energyText;

	// Use this for initialization
	void Start () 
	{
		if(eDecreaseEvent == null)
		{	
			eDecreaseEvent = new EnergyDecreaseEvent();
		}
		if(playerKillEvent == null)
		{	
			playerKillEvent = new UnityEvent();
		}
		InvokeRepeating("DecreaseEnergyAuto", 1.0f, 1.0f);
		InvokeRepeating("IncreaseFog", 1.0f, 0.5f);
	}


	void DecreaseEnergyAuto()
	{
		energyPoints -= decreaseRate;
		energyPoints = Mathf.Clamp(energyPoints, 0, 50);
		eDecreaseEvent.Invoke(energyPoints);

		if(energyPoints <= 0)
		{
			energyPoints = 0;
			playerKillEvent.Invoke();
			CancelInvoke();
		}

		if(energyText != null)
		energyText.GetComponent<Text>().text = "Energy: "+energyPoints;
	}

	void IncreaseFog()
	{
		RenderSettings.fogEndDistance = (energyPoints + 25f)/2.5f;
		RenderSettings.fogEndDistance = Mathf.Clamp(RenderSettings.fogEndDistance, 10, 50);
	}

	public void IncreaseEnergyByPhoton()
	{
		// ChangeEnergy(5);

		energyPoints += 5;
		if(energyText != null)
		energyText.GetComponent<Text>().text = "Energy: "+energyPoints;
	}

	public void ChangeEnergy(float byVal)
	{
		energyPoints += byVal;
		if(energyText != null)
		energyText.GetComponent<Text>().text = "Energy: "+energyPoints;
	}
	
}
