using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TrapPickupEvent : UnityEvent<float>
{
	
}

public class PhotonPickup : MonoBehaviour {

	public UnityEvent PhotonPickupEvent;
	public TrapPickupEvent trapPickupEvent;
	void Start()
	{
		if(PhotonPickupEvent == null)
		{
			PhotonPickupEvent = new UnityEvent();
		}

		if(trapPickupEvent == null)
		{
			trapPickupEvent = new TrapPickupEvent();
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("Photon"))
		{
			// Debug.Log("picked up");

			PhotonPickupEvent.Invoke();
			// Debug.Log(other.gameObject.name);
			Destroy(other.gameObject);
			
		}

		else if(other.tag.Equals("Pinchos"))
		{
			Debug.Log("Hit spikes");
			trapPickupEvent.Invoke(-4.0f);
		}
		// Debug.Log(other.gameObject.tag);
	}
	
}
