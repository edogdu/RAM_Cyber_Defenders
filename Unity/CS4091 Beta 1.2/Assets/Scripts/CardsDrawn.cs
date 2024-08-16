using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will check the card the opponent has drawn and will display it on a screen somewhere, and perhaps more later
public class CardsDrawn : MonoBehaviour
{
	// This will allow the script to call functions from the DeckManager script to check the current drawn card
	[SerializeField] public DeckManager deckScript;
	
	[SerializeField] public GameObject CellPhone;
	[SerializeField] public GameObject Computer;
	[SerializeField] public GameObject GameConsole;
	[SerializeField] public GameObject PrivateInfo;
	[SerializeField] public GameObject Encryption;
	[SerializeField] public GameObject FireWall;
	[SerializeField] public GameObject AntiMalware;
	[SerializeField] public GameObject Education;
	[SerializeField] public GameObject WirelessAttack;
	[SerializeField] public GameObject Hacker;
	[SerializeField] public GameObject Malware;
	[SerializeField] public GameObject Phising;
	[SerializeField] public GameObject CyberAttack;
	public int Screen; 
	

    // Update is called once per frame
    void Update()
    {
		if (deckScript.currentDrawnCard != null)
		{
			if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetPlayer() == 1 && Screen == 1)
			{
				if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetColor() == 1) // Blue Asset Cards
					BlueCard();
				else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetColor() == 2) // Green Defense Cards
					GreenCard();
				else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetColor() == 3) // Red Attack Cards
					RedCard();
			}
			else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetPlayer() == 2 && Screen == 2)
			{
				if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetColor() == 1) // Blue Asset Cards
					BlueCard();
				else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetColor() == 2) // Green Defense Cards
					GreenCard();
				else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetColor() == 3) // Red Attack Cards
					RedCard();
			}	
		}
    }
	
	public void BlueCard()
	{
		if (deckScript.currentDrawnCard != null)
		{
			if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 1) // Cellphone
			{
				HideAll();
				CellPhone.SetActive(true);
			}
			else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 2) // Computer
			{
				HideAll();
				Computer.SetActive(true);
			}
			else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 3) // Game Console
			{
				HideAll();
				GameConsole.SetActive(true);
			}
			else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 4) // Private Information
			{
				HideAll();
				PrivateInfo.SetActive(true);
			}
		}
	}
	
	public void GreenCard()
	{
		if (deckScript.currentDrawnCard != null)
		{
			if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 1) // Encryption
			{
				HideAll();
				Encryption.SetActive(true);
			}
			else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 2) // Fire Wall
			{
				HideAll();
				FireWall.SetActive(true);
			}
			else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 3) // Anti Malware
			{
				HideAll();
				AntiMalware.SetActive(true);
			}
			else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 4) // Education
			{
				HideAll();
				Education.SetActive(true);
			}
		}
	}
	
	public void RedCard()
	{
		if (deckScript.currentDrawnCard != null)
		{
			if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 1) // Wireless Attack
			{
				HideAll();
				WirelessAttack.SetActive(true);
			}
			else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 2) //Hacker
			{
				HideAll();
				Hacker.SetActive(true);
			}
			else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 3) // Malware
			{
				HideAll();
				Malware.SetActive(true);
			}
			else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 4) // Phising
			{
				HideAll();
				Phising.SetActive(true);
			}
			else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 5) // CyberAttack
			{
				HideAll();
				CyberAttack.SetActive(true);
			}
		}
	}
	
	public void HideAll()
	{
		CellPhone.SetActive(false);
		Computer.SetActive(false);
		GameConsole.SetActive(false);
		PrivateInfo.SetActive(false);
		Encryption.SetActive(false);
		FireWall.SetActive(false);
		AntiMalware.SetActive(false);
		Education.SetActive(false);
		WirelessAttack.SetActive(false);
		Hacker.SetActive(false);
		Malware.SetActive(false);
		Phising.SetActive(false);
		CyberAttack.SetActive(false);
	}
}
