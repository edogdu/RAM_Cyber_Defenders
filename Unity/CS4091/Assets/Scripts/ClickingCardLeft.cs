using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickingCardLeft : MonoBehaviour
{
    public TMP_Text cardDecktext;
    public int numbersOfCards = 50;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            numbersOfCards--;
            if (numbersOfCards <= 0)
                numbersOfCards = 0;
            cardDecktext.text = "Cards Left: " + numbersOfCards;

        }
    }
}
