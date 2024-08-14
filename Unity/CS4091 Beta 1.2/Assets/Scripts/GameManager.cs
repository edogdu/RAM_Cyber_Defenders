using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject Board;
    [SerializeField] public GameObject Pause;
    [SerializeField] public GameObject PlayAgainButton;
    [SerializeField] public GameObject WinBackground;
    [SerializeField] public GameObject TieBackground;
    [SerializeField] public GameObject LoseBackground;
    [SerializeField] public TextMeshProUGUI displayPlayerScore;
    [SerializeField] public TextMeshProUGUI displayAIScore;

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
    }

    // Update is called once per frame
    void Update()
    {
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
        int Player1count = 0;
        int Player2count = 0;
        foreach (GameObject socket in blueSocketsPlayer1)
        {
            XRSocketCardHandler socketHandler = socket.GetComponent<XRSocketCardHandler>();
            if (socketHandler != null && socketHandler.IsOccupied() == true)
            {
                Player1count++;
            }
        }
        foreach (GameObject socket in blueSocketsPlayer2)
        {
            XRSocketCardHandler socketHandler = socket.GetComponent<XRSocketCardHandler>();
            if (socketHandler != null && socketHandler.IsOccupied() == true)
            {
                Player2count++;
            }
        }
        Board.SetActive(true);
        PlayAgainButton.SetActive(true);
        Pause.SetActive(false);
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
}
