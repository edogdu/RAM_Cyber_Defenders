using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageCardLeft : MonoBehaviour
{
    public TMP_Text message;
    public int numbersOfCards = 50;
    //public GameObject cardDeck;

    void Start()
    {
        message.text = "Cards Left: " + numbersOfCards;
    }


    void Update()
    {

    }

}
