using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int decidedTurn; //1 is player 1 turn, 2 player 2 turn;
    public bool isTurnOnGoing = true;
    // Start is called before the first frame update
    void Start()
    {
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
}
