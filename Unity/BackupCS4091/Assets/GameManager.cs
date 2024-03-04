using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int turnCount;
    public bool decidedTurn; //false is player 1 turn, true = play 2 turn;
    // Start is called before the first frame update
    void Start()
    {
        turnCount = 0;
        decidedTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(turnCount % 2 == 0)
        {
            decidedTurn = false;
        }
        else
        {
            decidedTurn = true;
        }
    }

    public void increaseTurn()
    {
        turnCount++;
    }
}
