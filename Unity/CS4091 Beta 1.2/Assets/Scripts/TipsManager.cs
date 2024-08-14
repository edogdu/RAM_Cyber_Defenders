using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
	// All Tips windows and buttons in the environment
	[SerializeField] public GameObject FirstDraw;
	[SerializeField] public GameObject GreenDiscard;
	[SerializeField] public GameObject RedDiscard;
	[SerializeField] public GameObject PlayBlue;
	[SerializeField] public GameObject PlayGreen;
	[SerializeField] public GameObject PlayRed;
	[SerializeField] public GameObject DisableTipsButton;
	[SerializeField] public GameObject DisabledTips;
	[SerializeField] public GameObject ToggleOffButton;
	[SerializeField] public GameObject ToggleOnButton;
	[SerializeField] public GameObject AlwaysGuideButton;
	[SerializeField] public GameObject NotAlwaysGuideButton;
	[SerializeField] public GameObject ControllerModel1;
	[SerializeField] public GameObject ControllerModel2;
	[SerializeField] public GameObject ControllerModel3;
	[SerializeField] public GameObject ControllerModel4;
	//[SerializeField] public GameObject BoxTrigger;
	
	
	// This will allow the script to call functions from the DeckManager script to check the current drawn card
	[SerializeField] public DeckManager deckScript;
	
	[SerializeField] public ColliderTrigger boxTrigger;
	
	// Player1's blue card guides
	[SerializeField] public GameObject BlueP1;
	[SerializeField] public GameObject BlueP2;
	[SerializeField] public GameObject BlueP3;
	[SerializeField] public GameObject BlueP4;
	[SerializeField] public GameObject BlueP5;
	[SerializeField] public GameObject BlueP6;
	[SerializeField] public GameObject BlueP7;
	[SerializeField] public GameObject BlueP8;
	
	// Player2's blue card guides
	[SerializeField] public GameObject BlueA1;
	[SerializeField] public GameObject BlueA2;
	[SerializeField] public GameObject BlueA3;
	[SerializeField] public GameObject BlueA4;
	[SerializeField] public GameObject BlueA5;
	[SerializeField] public GameObject BlueA6;
	[SerializeField] public GameObject BlueA7;
	[SerializeField] public GameObject BlueA8;
	
	// Player1's green card guides
	[SerializeField] public GameObject GreenP1;
	[SerializeField] public GameObject GreenP2;
	[SerializeField] public GameObject GreenP3;
	[SerializeField] public GameObject GreenP4;
	[SerializeField] public GameObject GreenP5;
	[SerializeField] public GameObject GreenP6;
	[SerializeField] public GameObject GreenP7;
	[SerializeField] public GameObject GreenP8;
	
	// Player2's green card guides
	[SerializeField] public GameObject GreenA1;
	[SerializeField] public GameObject GreenA2;
	[SerializeField] public GameObject GreenA3;
	[SerializeField] public GameObject GreenA4;
	[SerializeField] public GameObject GreenA5;
	[SerializeField] public GameObject GreenA6;
	[SerializeField] public GameObject GreenA7;
	[SerializeField] public GameObject GreenA8;
	
	// Players1's red card guides
	[SerializeField] public GameObject RedP1;
	[SerializeField] public GameObject RedP2;
	[SerializeField] public GameObject RedP3;
	[SerializeField] public GameObject RedP4;
	[SerializeField] public GameObject RedP5;
	[SerializeField] public GameObject RedP6;
	[SerializeField] public GameObject RedP7;
	[SerializeField] public GameObject RedP8;
	
	// Players2's red card guides
	[SerializeField] public GameObject RedA1;
	[SerializeField] public GameObject RedA2;
	[SerializeField] public GameObject RedA3;
	[SerializeField] public GameObject RedA4;
	[SerializeField] public GameObject RedA5;
	[SerializeField] public GameObject RedA6;
	[SerializeField] public GameObject RedA7;
	[SerializeField] public GameObject RedA8;
	
	// If the card can't be used, the discard pile will be highlighted
	[SerializeField] public GameObject DiscardP1;
	[SerializeField] public GameObject DiscardP2;
	[SerializeField] public GameObject Discard1;
	[SerializeField] public GameObject Discard2;
	
	
	// All eight Player1 blue sockets, from which we can determine the info of the blue cards on the board, and how they should interact with green and red cards
	[SerializeField] public XRSocketCardHandler socketP1;
	[SerializeField] public XRSocketCardHandler socketP2;
	[SerializeField] public XRSocketCardHandler socketP3;
	[SerializeField] public XRSocketCardHandler socketP4;
	[SerializeField] public XRSocketCardHandler socketP5;
	[SerializeField] public XRSocketCardHandler socketP6;
	[SerializeField] public XRSocketCardHandler socketP7;
	[SerializeField] public XRSocketCardHandler socketP8;
	
	// All eight Player2 / AI blue sockets
	[SerializeField] public XRSocketCardHandler socketA1;
	[SerializeField] public XRSocketCardHandler socketA2;
	[SerializeField] public XRSocketCardHandler socketA3;
	[SerializeField] public XRSocketCardHandler socketA4;
	[SerializeField] public XRSocketCardHandler socketA5;
	[SerializeField] public XRSocketCardHandler socketA6;
	[SerializeField] public XRSocketCardHandler socketA7;
	[SerializeField] public XRSocketCardHandler socketA8;
	
	// All eight Player1 green sockets, to check if a green socket is already occupied
	[SerializeField] public GreenSocketCardHandler socketGP1;
	[SerializeField] public GreenSocketCardHandler socketGP2;
	[SerializeField] public GreenSocketCardHandler socketGP3;
	[SerializeField] public GreenSocketCardHandler socketGP4;
	[SerializeField] public GreenSocketCardHandler socketGP5;
	[SerializeField] public GreenSocketCardHandler socketGP6;
	[SerializeField] public GreenSocketCardHandler socketGP7;
	[SerializeField] public GreenSocketCardHandler socketGP8;
	
	// All eight Player2/ AI green sockets
	[SerializeField] public GreenSocketCardHandler socketGA1;
	[SerializeField] public GreenSocketCardHandler socketGA2;
	[SerializeField] public GreenSocketCardHandler socketGA3;
	[SerializeField] public GreenSocketCardHandler socketGA4;
	[SerializeField] public GreenSocketCardHandler socketGA5;
	[SerializeField] public GreenSocketCardHandler socketGA6;
	[SerializeField] public GreenSocketCardHandler socketGA7;
	[SerializeField] public GreenSocketCardHandler socketGA8;
	
	public CardsInformation currentCard;
	
	
	int Tip1 = 0; // After a tip is shown, it's int will be changed to one, and it won't show again that game
	int Tip2 = 0;
	int Tip3 = 0;
	int Tip4 = 0;
	int Tip5 = 0;
	int Tip6 = 0;
	
	int CardGuide = 0; // Int used to change the 'Toggle Guide' button between it's two states of On or Off
	
	int AlwaysGuide = 0;
	
	int currentPlayer = 1; // Changes between 1 and 2 to determine which Player's turn it is
	
	//int delay = 0;
	
	void Update()
    {	// If all tips have been shown and used, hide the 'Disable Tips' button
        if(Tip2 == 1 && Tip3 == 1 && Tip4 == 1 && Tip5 == 1 && Tip6 == 1)
		{
			DisableTipsButton.SetActive(false);
			DisabledTips.SetActive(true);
		}
		
		if (deckScript.currentDrawnCard != null)
		{
			currentCard = deckScript.currentDrawnCard.GetComponent<CardsInformation>();
		}
		
		// Check Player1 blue sockets to see if a green card can be used or not
		if(currentCard.GetColor() == 2 && currentCard.GetPlayer() == 1)
		{
			if((socketP1.GetCardType() == currentCard.GetSymbol() && socketP1.IsOccupied() == true) // Checks the first blue socket for a matching card to the drawn green card, and checks if the blue card is still there
			|| (socketP2.GetCardType() == currentCard.GetSymbol() && socketP2.IsOccupied() == true)
			|| (socketP3.GetCardType() == currentCard.GetSymbol() && socketP3.IsOccupied() == true)
			|| (socketP4.GetCardType() == currentCard.GetSymbol() && socketP4.IsOccupied() == true)
			|| (socketP5.GetCardType() == currentCard.GetSymbol() && socketP5.IsOccupied() == true)	
			|| (socketP6.GetCardType() == currentCard.GetSymbol() && socketP6.IsOccupied() == true)	
			|| (socketP7.GetCardType() == currentCard.GetSymbol() && socketP7.IsOccupied() == true)
			|| (socketP8.GetCardType() == currentCard.GetSymbol() && socketP8.IsOccupied() == true))
			{
				PlayGreenCard(); // Function in the script that handles one of the Tips windows 
			}
			else
			{
				PlayGreen.SetActive(false); // If the green card to use suddenly can't be used to due to an opponent's red card, hide the tip window
				DiscardGreenCard();
			}
		}
		
		// Check Player2 / AI blue sockets to see if a red card can be used or not
		if(currentCard.GetColor() == 3 && currentCard.GetPlayer() == 1)
		{
			if(socketA1.GetCardType() == currentCard.GetSymbol() // Checks if Player1's red card matches the opponent's blue card (or lack of card) in the first opponent blue socket
			|| socketA2.GetCardType() == currentCard.GetSymbol()
			|| socketA3.GetCardType() == currentCard.GetSymbol()
			|| socketA4.GetCardType() == currentCard.GetSymbol()
			|| socketA5.GetCardType() == currentCard.GetSymbol()	
			|| socketA6.GetCardType() == currentCard.GetSymbol()	
			|| socketA7.GetCardType() == currentCard.GetSymbol()
			|| socketA8.GetCardType() == currentCard.GetSymbol())
			{
				PlayRedCard();
			} // Checks for a cyber attack card and if it can be used
			else if(currentCard.GetSymbol() == 5 &&
			  (socketA1.GetCardType() != 0 // A cyber attack can destroy any card, so this checks that the opponent's blue socket isn't empty
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
		
		
		// Hide any active tips and the Player1 card guide when it's the AI's / Player2's turn
		if(currentCard.GetPlayer() == 2)
		{
			HideTips();
			HidePlayer1Guide();
		}
		
		// Hide Player2 / AI's card guide when it's Player1's turn
		if(currentCard.GetPlayer() == 1)
		{
			HidePlayer2Guide();
		}
		
		
		// Check if the next Player1 card is a blue card for tips
		if(currentCard.GetColor() == 1 
			&& currentCard.GetPlayer() == 1)
		{
			PlayBlueCard();
		}
		
		if(currentCard.GetPlayer() == 1)
		{
			currentPlayer = 1;
		}
		else if(currentCard.GetPlayer() == 2)
		{
			currentPlayer = 2;
		}
		
		if(currentPlayer == 1)
		{
			HidePlayer2Guide();
		}
		
		if(currentPlayer == 2)
		{
			HidePlayer1Guide();
		}
		
		// If the card guides are toggled on, they will show, or if toggled off, they will not show, as well as if the card is not sitting on the draw pile (if this setting is set)
		if(CardGuide == 0 && (boxTrigger.cardIsOnDeck() == false || AlwaysGuide == 1) )
		{
			
				// Check if the next Player1 card is a blue card for card guide
				if(currentCard.GetColor() == 1 
					&& currentCard.GetPlayer() == 1)
				{
					P1BlueGuide(); // Function in the script that show where blue cards can be placed
				}
				
				// Next P1 card is Green
				if(currentCard.GetColor() == 2 
					&& currentCard.GetPlayer() == 1)
				{
					P1GreenGuide();
				}
				
				// Next P1 card is Red
				if(currentCard.GetColor() == 3 
					&& currentCard.GetPlayer() == 1)
				{
					P1RedGuide();
				}
					
				// Next AI / P2 card is Blue
				if(currentCard.GetColor() == 1 
					&& currentCard.GetPlayer() == 2)
				{
					P2BlueGuide();
				}
				
				// Next AI / P2 card is Green
				if(currentCard.GetColor() == 2 
					&& currentCard.GetPlayer() == 2)
				{
					P2GreenGuide();
				}
				
				// Next AI / P2 card is Red
				if(currentCard.GetColor() == 3 
					&& currentCard.GetPlayer() == 2)
				{
					P2RedGuide();
				}
				
		}
		else
		{
			HidePlayer1Guide();
			HidePlayer2Guide();
		}
    }
	
    public void DrawFirstCard()
	{	// Instructs player on how to draw the first card
		if (Tip1 == 0)
		{
			FirstDraw.SetActive(true);
			ControllerModel1.SetActive(true);
			Tip1 = 1;
		}
	}
	
	public void DiscardGreenCard()
	{	// Instructs player to discard a green card that can't be used
		if (Tip2 == 0)
		{
			GreenDiscard.SetActive(true);
			ControllerModel4.SetActive(true);
			Tip2 = 1;
		}
	}
	
	public void DiscardRedCard()
	{   // Instructs player to discard a red card that can't be used
		if (Tip3 == 0)
		{
			RedDiscard.SetActive(true);
			ControllerModel4.SetActive(true);
			Tip3 = 1;
		}
	}
	
	public void PlayBlueCard()
	{	// Instructs player to play a blue card
		if (Tip4 == 0)
		{
			PlayBlue.SetActive(true);
			Tip4 = 1;
		}
	}
	
	public void PlayGreenCard()
	{	// Instructs player to play a green card
		if (Tip5 == 0)
		{
			PlayGreen.SetActive(true);
			ControllerModel2.SetActive(true);
			Tip5 = 1;
		}
	}
	
	public void PlayRedCard()
	{	// Instructs player to play a red card
		if (Tip6 == 0)
		{
			PlayRed.SetActive(true);
			ControllerModel3.SetActive(true);
			Tip6 = 1;
		}
	}
	
	public void HideTips()
	{   // After Player1's turn, this function will hide any active tips windows
		FirstDraw.SetActive(false);
		GreenDiscard.SetActive(false);
		RedDiscard.SetActive(false);
		PlayBlue.SetActive(false);
		PlayGreen.SetActive(false);
		PlayRed.SetActive(false);
		ControllerModel1.SetActive(false);
		ControllerModel2.SetActive(false);
		ControllerModel3.SetActive(false);
		ControllerModel4.SetActive(false);
	}
	
	public void DisableTips() 
	{	// A button in the scene can be pressed so active tips will be hidden and more tips will not appear that game
		Tip1 = 1;
		Tip2 = 1;
		Tip3 = 1;
		Tip4 = 1;
		Tip5 = 1;
		Tip6 = 1;
		HideTips();
	}
	
	
	// Card Guides; Will display where the current card can be placed on the board; This will work for both players
	
	
	public void P1BlueGuide() // Available Player1 blue sockets will glow
	{
		
		int guide = 0; // Int used to see if a card needs to be discarded
		
		if(socketP1.IsOccupied() == false) // If the first blue socket is empty and can hold a new blue card
		{
			BlueP1.SetActive(true);
			guide += 1; // This will indicate that a card can be played and does not need to be discarded
		}
		
		if(socketP2.IsOccupied() == false)
		{
			BlueP2.SetActive(true);
			guide += 1;
		}
		
		if(socketP3.IsOccupied() == false)
		{
			BlueP3.SetActive(true);
			guide += 1;
		}
		
		if(socketP4.IsOccupied() == false)
		{
			BlueP4.SetActive(true);
			guide += 1;
		}
		
		if(socketP5.IsOccupied() == false)
		{
			BlueP5.SetActive(true);
			guide += 1;
		}
		
		if(socketP6.IsOccupied() == false)
		{
			BlueP6.SetActive(true);
			guide += 1;
		}
		
		if(socketP7.IsOccupied() == false)
		{
			BlueP7.SetActive(true);
			guide += 1;
		}
		
		if(socketP8.IsOccupied() == false)
		{
			BlueP8.SetActive(true);
			guide += 1;
		}
			
		if(guide == 0) // If no cards can be played on the board, the discard pile will be highlighted
		{
			DiscardP1.SetActive(true);
			Discard1.SetActive(true);
		}
	}
	
	public void P2BlueGuide() // Available Player2 / AI blue sockets will glow
	{
		int guide = 0;
		
		if(socketA1.IsOccupied() == false)
		{
			BlueA1.SetActive(true);
			guide += 1;
		}
		
		if(socketA2.IsOccupied() == false)
		{
			BlueA2.SetActive(true);
			guide += 1;
		}
		
		if(socketA3.IsOccupied() == false)
		{
			BlueA3.SetActive(true);
			guide += 1;
		}
		
		if(socketA4.IsOccupied() == false)
		{
			BlueA4.SetActive(true);
			guide += 1;
		}
		
		if(socketA5.IsOccupied() == false)
		{
			BlueA5.SetActive(true);
			guide += 1;
		}
		
		if(socketA6.IsOccupied() == false)
		{
			BlueA6.SetActive(true);
			guide += 1;
		}
		
		if(socketA7.IsOccupied() == false)
			BlueA7.SetActive(true);
			guide += 1;
		
		if(socketA8.IsOccupied() == false)
		{
			BlueA8.SetActive(true);
			guide += 1;
		}
			
		if(guide == 0)
		{
			DiscardP2.SetActive(true);
			Discard2.SetActive(true);
		}
	}
	
	public void P1GreenGuide()  // Available P1 green sockets will glow when blue and current green cards match
	{
		int guide = 0;
		
		if(socketP1.GetCardType() == currentCard.GetSymbol() && socketGP1.IsOccupied() == false) // Checks if drawn green card matches the undefensed blue card in the first socket
		{
			if(socketP1.IsOccupied() == true) // Checks if the matching blue card is still there
			{
				GreenP1.SetActive(true);
				guide += 1;
			}
			else if(socketP1.IsOccupied() == false) // Should the matching blue card be destroyed while you've drawn your green card, the highlighted area will no longer be highlighted
			{
				GreenP1.SetActive(false);
			}
		}
		
		if(socketP2.GetCardType() == currentCard.GetSymbol() && socketGP2.IsOccupied() == false)
		{
			if(socketP2.IsOccupied() == true)
			{
				GreenP2.SetActive(true);
				guide += 1;
			}
			else if(socketP2.IsOccupied() == false)
			{
				GreenP2.SetActive(false);
			}
		}
		
		if(socketP3.GetCardType() == currentCard.GetSymbol() && socketGP3.IsOccupied() == false)
		{
			if(socketP3.IsOccupied() == true)
			{
				GreenP3.SetActive(true);
				guide += 1;
			}
			else if(socketP3.IsOccupied() == false)
			{
				GreenP3.SetActive(false);
			}
		}
		
		if(socketP4.GetCardType() == currentCard.GetSymbol() && socketGP4.IsOccupied() == false)
		{
			if(socketP4.IsOccupied() == true)
			{
				GreenP4.SetActive(true);
				guide += 1;
			}
			else if(socketP4.IsOccupied() == false)
			{
				GreenP4.SetActive(false);
			}
		}
		
		if(socketP5.GetCardType() == currentCard.GetSymbol() && socketGP5.IsOccupied() == false)
		{
			if(socketP5.IsOccupied() == true)
			{
				GreenP5.SetActive(true);
				guide += 1;
			}
			else if(socketP5.IsOccupied() == false)
			{
				GreenP5.SetActive(false);
			}
		}
		
		if(socketP6.GetCardType() == currentCard.GetSymbol() && socketGP6.IsOccupied() == false)
		{
			if(socketP6.IsOccupied() == true)
			{
				GreenP6.SetActive(true);
				guide += 1;
			}
			else if(socketP6.IsOccupied() == false)
			{
				GreenP6.SetActive(false);
			}
		}
		
		if(socketP7.GetCardType() == currentCard.GetSymbol() && socketGP7.IsOccupied() == false)
		{
			if(socketP7.IsOccupied() == true)
			{
				GreenP7.SetActive(true);
				guide += 1;
			}
			else if(socketP7.IsOccupied() == false)
			{
				GreenP7.SetActive(false);
			}
		}
		
		if(socketP8.GetCardType() == currentCard.GetSymbol() && socketGP8.IsOccupied() == false)
		{
			if(socketP8.IsOccupied() == true)
			{
				GreenP8.SetActive(true);
				guide += 1;
			}
			else if(socketP8.IsOccupied() == false)
			{
				GreenP8.SetActive(false);
			}
		}
			
		if(guide == 0)
		{
			DiscardP1.SetActive(true);
			Discard1.SetActive(true);
		}
	}
	
	public void P2GreenGuide()  // Available P2 / AI green sockets will glow when blue and current green cards match
	{
		int guide = 0;
		
		if(socketA1.GetCardType() == currentCard.GetSymbol() && socketGA1.IsOccupied() == false)
		{
			if(socketA1.IsOccupied() == true)
			{
				GreenA1.SetActive(true);
				guide += 1;
			}
			else if(socketA1.IsOccupied() == false)
			{
				GreenA1.SetActive(false);
			}
		}
		
		if(socketA2.GetCardType() == currentCard.GetSymbol() && socketGA2.IsOccupied() == false)
		{
			if(socketA2.IsOccupied() == true)
			{
				GreenA2.SetActive(true);
				guide += 1;
			}
			else if(socketA2.IsOccupied() == false)
			{
				GreenA2.SetActive(false);
			}
		}
		
		if(socketA3.GetCardType() == currentCard.GetSymbol() && socketGA3.IsOccupied() == false)
		{
			if(socketA3.IsOccupied() == true)
			{
				GreenA3.SetActive(true);
				guide += 1;
			}
			else if(socketA3.IsOccupied() == false)
			{
				GreenA3.SetActive(false);
			}
		}
		
		if(socketA4.GetCardType() == currentCard.GetSymbol() && socketGA4.IsOccupied() == false)
		{
			if(socketA4.IsOccupied() == true)
			{
				GreenA4.SetActive(true);
				guide += 1;
			}
			else if(socketA4.IsOccupied() == false)
			{
				GreenA4.SetActive(false);
			}
		}
		
		if(socketA5.GetCardType() == currentCard.GetSymbol() && socketGA5.IsOccupied() == false)
		{
			if(socketA5.IsOccupied() == true)
			{
				GreenA5.SetActive(true);
				guide += 1;
			}
			else if(socketA5.IsOccupied() == false)
			{
				GreenA5.SetActive(false);
			}
		}
		
		if(socketA6.GetCardType() == currentCard.GetSymbol() && socketGA6.IsOccupied() == false)
		{
			if(socketA6.IsOccupied() == true)
			{
				GreenA6.SetActive(true);
				guide += 1;
			}
			else if(socketA6.IsOccupied() == false)
			{
				GreenA6.SetActive(false);
			}
		}
		
		if(socketA7.GetCardType() == currentCard.GetSymbol() && socketGA7.IsOccupied() == false)
		{
			if(socketA7.IsOccupied() == true)
			{
				GreenA7.SetActive(true);
				guide += 1;
			}
			else if(socketA7.IsOccupied() == false)
			{
				GreenA7.SetActive(false);
			}
		}
		
		if(socketA8.GetCardType() == currentCard.GetSymbol() && socketGA8.IsOccupied() == false)
		{
			if(socketA8.IsOccupied() == true)
			{
				GreenA8.SetActive(true);
				guide += 1;
			}
			else if(socketA8.IsOccupied() == false)
			{
				GreenA8.SetActive(false);
			}
		}
			
		if(guide == 0)
		{
			DiscardP2.SetActive(true);
			Discard2.SetActive(true);
		}
	}
	
	public void P1RedGuide()  // Available P1 red sockets will glow when a corresponding blue or green opponent card can be destroyed
	{
		int guide = 0;
		
		// If the first opponent's blue card matches your drawn red card (or you drew a cyber attack card) it will show that you can play that card
		if(socketA1.IsOccupied() == true && (socketA1.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedP1.SetActive(true);
			guide += 1;
		}
		
		if(socketA2.IsOccupied() == true && (socketA2.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedP2.SetActive(true);
			guide += 1;
		}
		
		if(socketA3.IsOccupied() == true && (socketA3.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedP3.SetActive(true);
			guide += 1;
		}
		
		if(socketA4.IsOccupied() == true && (socketA4.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedP4.SetActive(true);
			guide += 1;
		}
		
		if(socketA5.IsOccupied() == true && (socketA5.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedP5.SetActive(true);
			guide += 1;
		}
		
		if(socketA6.IsOccupied() == true && (socketA6.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedP6.SetActive(true);
			guide += 1;
		}
		
		if(socketA7.IsOccupied() == true && (socketA7.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedP7.SetActive(true);
			guide += 1;
		}
		
		if(socketA8.IsOccupied() == true && (socketA8.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedP8.SetActive(true);
			guide += 1;
		}
			
		if(guide == 0)
		{
			DiscardP1.SetActive(true);
			Discard1.SetActive(true);
		}
	}
	
	public void P2RedGuide() // Available P2 / AI red sockets will glow when a corresponding blue or green opponent card can be destroyed
	{
		int guide = 0;
		
		if(socketP1.IsOccupied() == true && (socketP1.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedA1.SetActive(true);
			guide += 1;
		}
		
		if(socketP2.IsOccupied() == true && (socketP2.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedA2.SetActive(true);
			guide += 1;
		}
		
		if(socketP3.IsOccupied() == true && (socketP3.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedA3.SetActive(true);
			guide += 1;
		}
		
		if(socketP4.IsOccupied() == true && (socketP4.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedA4.SetActive(true);
			guide += 1;
		}
		
		if(socketP5.IsOccupied() == true && (socketP5.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedA5.SetActive(true);
			guide += 1;
		}
		
		if(socketP6.IsOccupied() == true && (socketP6.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedA6.SetActive(true);
			guide += 1;
		}
		
		if(socketP7.IsOccupied() == true && (socketP7.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedA7.SetActive(true);
			guide += 1;
		}
		
		if(socketP8.IsOccupied() == true && (socketP8.GetCardType() == currentCard.GetSymbol() || currentCard.GetSymbol() == 5))
		{
			RedA8.SetActive(true);
			guide += 1;
		}
			
		if(guide == 0)
		{
			DiscardP2.SetActive(true);
			Discard2.SetActive(true);
		}
	}
	
	public void HidePlayer1Guide() // Function to hide all P1 card guides that's called when it P2's turn
	{
		BlueP1.SetActive(false);
		BlueP2.SetActive(false);
		BlueP3.SetActive(false);
		BlueP4.SetActive(false);
		BlueP5.SetActive(false);
		BlueP6.SetActive(false);
		BlueP7.SetActive(false);
		BlueP8.SetActive(false);
		GreenP1.SetActive(false);
		GreenP2.SetActive(false);
		GreenP3.SetActive(false);
		GreenP4.SetActive(false);
		GreenP5.SetActive(false);
		GreenP6.SetActive(false);
		GreenP7.SetActive(false);
		GreenP8.SetActive(false);
		RedP1.SetActive(false);
		RedP2.SetActive(false);
		RedP3.SetActive(false);
		RedP4.SetActive(false);
		RedP5.SetActive(false);
		RedP6.SetActive(false);
		RedP7.SetActive(false);
		RedP8.SetActive(false);
		DiscardP1.SetActive(false);
		Discard1.SetActive(false);
	}
	
	public void HidePlayer2Guide() // Function to hide all P2 card guides that's called when it P1's turn
	{
		BlueA1.SetActive(false);
		BlueA2.SetActive(false);
		BlueA3.SetActive(false);
		BlueA4.SetActive(false);
		BlueA5.SetActive(false);
		BlueA6.SetActive(false);
		BlueA7.SetActive(false);
		BlueA8.SetActive(false);
		GreenA1.SetActive(false);
		GreenA2.SetActive(false);
		GreenA3.SetActive(false);
		GreenA4.SetActive(false);
		GreenA5.SetActive(false);
		GreenA6.SetActive(false);
		GreenA7.SetActive(false);
		GreenA8.SetActive(false);
		RedA1.SetActive(false);
		RedA2.SetActive(false);
		RedA3.SetActive(false);
		RedA4.SetActive(false);
		RedA5.SetActive(false);
		RedA6.SetActive(false);
		RedA7.SetActive(false);
		RedA8.SetActive(false);
		DiscardP2.SetActive(false);
		Discard2.SetActive(false);
	}
	
	public void ToggleGuide() // This function will switch between disabling or enabling card guides on the board every time the button is pressed
	{
		if(CardGuide == 0)
		{
			CardGuide = 1;
			ToggleOffButton.SetActive(false);
			ToggleOnButton.SetActive(true);
		}
		else if(CardGuide == 1)
		{
			CardGuide = 0;
			ToggleOffButton.SetActive(true);
			ToggleOnButton.SetActive(false);
		}
	}
	
	public void GuideAlwaysActive() // This function will switch between having card guides always show or only shown when the next card has been drawn
	{
		if(AlwaysGuide == 0)
		{
			AlwaysGuide = 1;
			AlwaysGuideButton.SetActive(false);
			NotAlwaysGuideButton.SetActive(true);
		}
		else if(AlwaysGuide == 1)
		{
			AlwaysGuide = 0;
			AlwaysGuideButton.SetActive(true);
			NotAlwaysGuideButton.SetActive(false);
		}
	}
	
	
}
