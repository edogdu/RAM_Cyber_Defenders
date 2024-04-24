
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageWasted : MonoBehaviour
{
    public TMP_Text message;
    public int WastedCards = 0;
    //public GameObject abandonedDeck;

    void Start()
    {
        //message.text = "Wasted Card: " + WastedCards;
    }


    void Update()
    {
        message.text = "Wasted Card: " + WastedCards;
    }

    public void increaseCount()
    {
        WastedCards++;
    }

}