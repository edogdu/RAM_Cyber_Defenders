using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    //[SerializeField] private GameObject[] targets;
	
	public bool CardOnDeck;
	
	void OnTriggerEnter(Collider other)
	{
		CardOnDeck = true;
	}
	
	void OnTriggerExit(Collider other)
	{
		CardOnDeck = false;
	}
	
	public bool cardIsOnDeck()
	{
		return CardOnDeck;
	}
}
