using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickingCardLeft : MonoBehaviour
{
    public TMP_Text cardDecktext;
    public DeckManager deckManager;
    public int numbersOfCards = 50;

    // Start is called before the first frame update
    void Start()
    {
        deckManager = GetComponent<DeckManager>();
        if (deckManager == null)
        {
            Debug.LogError("DeckManager not found in the scene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        cardDecktext.text = "Cards Left: " + deckManager.ReorderDeckCount;
    }
}