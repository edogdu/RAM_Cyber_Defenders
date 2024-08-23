using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject Board;
    [SerializeField] public GameObject Pause;
    [SerializeField] public GameObject CardsGuide;
	[SerializeField] public GameObject PlayAgainButton;
	[SerializeField] public GameObject GuidesButton;
	
	[SerializeField] public GameObject NeutralBackground;
	[SerializeField] public GameObject WinningBackground;
	[SerializeField] public GameObject Winning2Background;
	[SerializeField] public GameObject LosingBackground;
	[SerializeField] public GameObject Losing2Background;
    [SerializeField] public GameObject WinBackground;
    [SerializeField] public GameObject TieBackground;
    [SerializeField] public GameObject LoseBackground;
	
    [SerializeField] public TextMeshProUGUI displayPlayerScore;
    [SerializeField] public TextMeshProUGUI displayAIScore;
	
	
	// All eight Player1 and Player2 sockets to make determining score easier
	[SerializeField] public XRSocketCardHandler socketP1;
	[SerializeField] public XRSocketCardHandler socketP2;
	[SerializeField] public XRSocketCardHandler socketP3;
	[SerializeField] public XRSocketCardHandler socketP4;
	[SerializeField] public XRSocketCardHandler socketP5;
	[SerializeField] public XRSocketCardHandler socketP6;
	[SerializeField] public XRSocketCardHandler socketP7;
	[SerializeField] public XRSocketCardHandler socketP8;
	
	[SerializeField] public XRSocketCardHandler socketA1;
	[SerializeField] public XRSocketCardHandler socketA2;
	[SerializeField] public XRSocketCardHandler socketA3;
	[SerializeField] public XRSocketCardHandler socketA4;
	[SerializeField] public XRSocketCardHandler socketA5;
	[SerializeField] public XRSocketCardHandler socketA6;
	[SerializeField] public XRSocketCardHandler socketA7;
	[SerializeField] public XRSocketCardHandler socketA8;
	
	// int to count up how many points both Players have
	int P1, P2, P3, P4, P5, P6, P7, P8, A1, A2, A3, A4, A5, A6, A7, A8;
	
	
	int Player1count = 0;
    int Player2count = 0;
	bool gameFinished = false;

    public int decidedTurn; //1 is pPlayAgainButton;layer 1 turn, 2 player 2 turn;

    private GameObject[] blueSocketsPlayer1; // Store references to blue sockets for Player 1
    private GameObject[] blueSocketsPlayer2; // Store references to blue sockets for Player 1
    // Start is called before the first frame update
    void Start()
    {
        blueSocketsPlayer1 = GameObject.FindGameObjectsWithTag("BlueSocket");
        blueSocketsPlayer2 = GameObject.FindGameObjectsWithTag("BlueSocketPlayer2");
        Debug.LogWarning("Number of blue sockets found: " + blueSocketsPlayer1.Length);
        Debug.LogWarning("Number of blue sockets found: " + blueSocketsPlayer2.Length);
        decidedTurn = 1;
		
		displayPlayerScore.text = Player1count.ToString();
        displayAIScore.text = Player2count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
		if(socketP1.IsOccupied() == true) // If the first socket has a blue card, count the point towards Player1's total
			P1 = 1;
		else
			P1 = 0;
		if(socketP2.IsOccupied() == true)
			P2 = 1;
		else
			P2 = 0;
		if(socketP3.IsOccupied() == true)
			P3 = 1;
		else
			P3 = 0;
		if(socketP4.IsOccupied() == true)
			P4 = 1;
		else
			P4 = 0;
		if(socketP5.IsOccupied() == true)
			P5 = 1;
		else
			P5 = 0;
		if(socketP6.IsOccupied() == true)
			P6 = 1;
		else
			P6 = 0;
		if(socketP7.IsOccupied() == true)
			P7 = 1;
		else
			P7 = 0;
		if(socketP8.IsOccupied() == true)
			P8 = 1;
		else
			P8 = 0;
		if(socketA1.IsOccupied() == true)
			A1 = 1;
		else
			A1 = 0;
		if(socketA2.IsOccupied() == true)
			A2 = 1;
		else
			A2 = 0;
		if(socketA3.IsOccupied() == true)
			A3 = 1;
		else
			A3 = 0;
		if(socketA4.IsOccupied() == true)
			A4 = 1;
		else
			A4 = 0;
		if(socketA5.IsOccupied() == true)
			A5 = 1;
		else
			A5 = 0;
		if(socketA6.IsOccupied() == true)
			A6 = 1;
		else
			A6 = 0;
		if(socketA7.IsOccupied() == true)
			A7 = 1;
		else
			A7 = 0;
		if(socketA8.IsOccupied() == true)
			A8 = 1;
		else
			A8 = 0;
		
        Player1count = P1 + P2 + P3 + P4 + P5 + P6 + P7 + P8;
		Player2count = A1 + A2 + A3 + A4 + A5 + A6 + A7 + A8;
		
		displayPlayerScore.text = Player1count.ToString();
        displayAIScore.text = Player2count.ToString();
		
		// Tried with making the board change color depending on the point difference between the players, could have potential for other effects
		
		if(gameFinished == false)
		{
			if(Player1count == Player2count)
			{
				NeutralBackground.SetActive(true);
				WinningBackground.SetActive(false);
				Winning2Background.SetActive(false);
				LosingBackground.SetActive(false);
				Losing2Background.SetActive(false);
			}
			else if(Player1count - 1 == Player2count)
			{
				NeutralBackground.SetActive(false);
				WinningBackground.SetActive(true);
				Winning2Background.SetActive(false);
				LosingBackground.SetActive(false);
				Losing2Background.SetActive(false);
			}
			else if(Player1count > Player2count + 1)
			{
				NeutralBackground.SetActive(false);
				WinningBackground.SetActive(false);
				Winning2Background.SetActive(true);
				LosingBackground.SetActive(false);
				Losing2Background.SetActive(false);
			}
			else if(Player1count == Player2count - 1)
			{
				NeutralBackground.SetActive(false);
				WinningBackground.SetActive(false);
				Winning2Background.SetActive(false);
				LosingBackground.SetActive(true);
				Losing2Background.SetActive(false);
			}
			else if(Player1count + 1 < Player2count)
			{
				NeutralBackground.SetActive(false);
				WinningBackground.SetActive(false);
				Winning2Background.SetActive(false);
				LosingBackground.SetActive(false);
				Losing2Background.SetActive(true);
			}
		}
		
    }

    public void switchTurn()
    {
        if (decidedTurn == 1)
        {
            decidedTurn = 2;
        }
        else
        {
            decidedTurn = 1;
        }
    }

    public int determineWin()
    {
        //int Player1count = 0;
        //int Player2count = 0;
        //foreach (GameObject socket in blueSocketsPlayer1)
        //{
        //    XRSocketCardHandler socketHandler = socket.GetComponent<XRSocketCardHandler>();
        //    if (socketHandler != null && socketHandler.IsOccupied() == true)
        //    {
        //        Player1count++;
        //    }
        //}
        //foreach (GameObject socket in blueSocketsPlayer2)
        //{
        //    XRSocketCardHandler socketHandler = socket.GetComponent<XRSocketCardHandler>();
        //    if (socketHandler != null && socketHandler.IsOccupied() == true)
        //    {
        //        Player2count++;
        //    }
        //}
		
        //Board.SetActive(true);
		
		gameFinished = true;
		
		NeutralBackground.SetActive(false);
		WinningBackground.SetActive(false);
		Winning2Background.SetActive(false);
		LosingBackground.SetActive(false);
		Losing2Background.SetActive(false);
			
		CardsGuide.SetActive(false);
        PlayAgainButton.SetActive(true);
        Pause.SetActive(false);
		GuidesButton.SetActive(false);
        displayPlayerScore.text = Player1count.ToString();
        displayAIScore.text = Player2count.ToString();
        if (Player1count > Player2count)
        {
            Debug.LogError("----Player 1 win----");
            WinBackground.SetActive(true);
            return 1;
        }
        else if(Player1count < Player2count)
        {
            Debug.LogError("----Player 2 win----");
            LoseBackground.SetActive(true);
            return 2;
        }
        else if (Player1count == Player2count)
        {
            Debug.LogError("----Tie----");
            TieBackground.SetActive(true);
            return 0;
        }
        return 0;
    }
	
	public int WhoWon()
	{
		if (Player1count > Player2count)
        {
            return 3;
        }
        else if(Player1count < Player2count)
        {
            return 1;
        }
        else if (Player1count == Player2count)
        {
            return 2;
        }
		return 0;
	}
}
