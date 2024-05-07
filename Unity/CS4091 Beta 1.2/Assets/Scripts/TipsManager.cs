using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
	
	[SerializeField] public GameObject FirstDraw;
	[SerializeField] public GameObject GreenDiscard;
	[SerializeField] public GameObject RedDiscard;
	[SerializeField] public GameObject PlayBlue;
	[SerializeField] public GameObject PlayGreen;
	[SerializeField] public GameObject PlayRed;
	[SerializeField] public GameObject DisableButton;
	
	[SerializeField] public DeckManager deckScript;
	
	// All eight player blue sockets
	[SerializeField] public XRSocketCardHandler socketP1;
	[SerializeField] public XRSocketCardHandler socketP2;
	[SerializeField] public XRSocketCardHandler socketP3;
	[SerializeField] public XRSocketCardHandler socketP4;
	[SerializeField] public XRSocketCardHandler socketP5;
	[SerializeField] public XRSocketCardHandler socketP6;
	[SerializeField] public XRSocketCardHandler socketP7;
	[SerializeField] public XRSocketCardHandler socketP8;
	
	// All eight AI blue sockets
	[SerializeField] public XRSocketCardHandler socketA1;
	[SerializeField] public XRSocketCardHandler socketA2;
	[SerializeField] public XRSocketCardHandler socketA3;
	[SerializeField] public XRSocketCardHandler socketA4;
	[SerializeField] public XRSocketCardHandler socketA5;
	[SerializeField] public XRSocketCardHandler socketA6;
	[SerializeField] public XRSocketCardHandler socketA7;
	[SerializeField] public XRSocketCardHandler socketA8;
	
	int Tip1 = 0; // After a tip is shown, it's int will be changed to one, and it won't show again that game
	int Tip2 = 0;
	int Tip3 = 0;
	int Tip4 = 0;
	int Tip5 = 0;
	int Tip6 = 0;
	
	void Update()
    {	// If all tips have been shown and used, hide the 'Disable Tips' button
        if(Tip2 == 1 && Tip3 == 1 && Tip4 == 1 && Tip5 == 1 && Tip6 == 1)
		{
			DisableButton.SetActive(false);
		}
		
		// Check player blue sockets to see if a green card can be used or not
		if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetColor() == 2 
			&& deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetPlayer() == 1)
		{
			if(socketP1.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()
			|| socketP2.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()
			|| socketP3.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()
			|| socketP4.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()
			|| socketP5.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()	
			|| socketP6.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()	
			|| socketP7.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()
			|| socketP8.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol())
			{
				PlayGreenCard();
			}
			else
			{
				DiscardGreenCard();
			}
		}
		
		// Check AI blue sockets to see if a red card can be used or not
		if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetColor() == 3 
			&& deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetPlayer() == 1)
		{
			if(socketA1.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()
			|| socketA2.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()
			|| socketA3.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()
			|| socketA4.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()
			|| socketA5.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()	
			|| socketA6.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()	
			|| socketA7.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol()
			|| socketA8.GetCardType() == deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol())
			{
				PlayRedCard();
			} // Checks for a cyber attack card and if it can be used
			else if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetSymbol() == 5 &&
			  (socketA1.GetCardType() != 0
			|| socketA2.GetCardType() != 0
			|| socketA3.GetCardType() != 0
			|| socketA4.GetCardType() != 0
			|| socketA5.GetCardType() != 0
			|| socketA6.GetCardType() != 0
			|| socketA7.GetCardType() != 0
			|| socketA8.GetCardType() != 0) )
			{
				PlayRedCard();
			}
			else
			{
				DiscardRedCard();
			}
		}
		
		// Check if the next player card is a blue card
		if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetColor() == 1 
			&& deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetPlayer() == 1)
		{
			PlayBlueCard();
		}
		
		// Hide the tip when it's the AI's turn
		if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetPlayer() == 2)
		{
			HideTips();
		}
    }
	
    public void DrawFirstCard()
	{	// Instructs player on how to draw the first card
		if (Tip1 == 0)
		{
			FirstDraw.SetActive(true);
			Tip1 = 1;
		}
	}
	
	public void DiscardGreenCard()
	{	// Instructs player to discard a green card that can't be used
		if (Tip2 == 0)
		{
			GreenDiscard.SetActive(true);
			Tip2 = 1;
		}
	}
	
	public void DiscardRedCard()
	{   // Instructs player to discard a red card that can't be used
		if (Tip3 == 0)
		{
			RedDiscard.SetActive(true);
			Tip3 = 1;
		}
	}
	
	public void PlayBlueCard()
	{	// Instructs player to discard a blue card
		if (Tip4 == 0)
		{
			PlayBlue.SetActive(true);
			Tip4 = 1;
		}
	}
	
	public void PlayGreenCard()
	{	// Instructs player to discard a green card
		if (Tip5 == 0)
		{
			PlayGreen.SetActive(true);
			Tip5 = 1;
		}
	}
	
	public void PlayRedCard()
	{	// Instructs player to discard a red card
		if (Tip6 == 0)
		{
			PlayRed.SetActive(true);
			Tip6 = 1;
		}
	}
	
	public void HideTips()
	{
		FirstDraw.SetActive(false);
		GreenDiscard.SetActive(false);
		RedDiscard.SetActive(false);
		PlayBlue.SetActive(false);
		PlayGreen.SetActive(false);
		PlayRed.SetActive(false);
	}
	
	public void DisableTips() 
	{	// A button in the scene can be pressed so tips will be hidden and will not appear that game
		Tip1 = 1;
		Tip2 = 1;
		Tip3 = 1;
		Tip4 = 1;
		Tip5 = 1;
		Tip6 = 1;
		HideTips();
	}
}
