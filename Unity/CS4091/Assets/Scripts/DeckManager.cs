using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<GameObject> cardPrefabs;
    private List<GameObject> deck = new List<GameObject>();
    private GameObject currentDrawnCard;
    private Vector3 initialDrawnCardPosition;

    void Start()
    {
        InitializeDeck();
        DrawCard();
    }

    void InitializeDeck()
    {
        deck.AddRange(cardPrefabs);
    }

    public GameObject DrawCard()
    {
        if (deck.Count == 0)
        {
            Debug.LogWarning("Deck is empty!");
            return null;
        }

        GameObject drawnCardPrefab = deck[0];
        deck.RemoveAt(0);

        // Instantiate the drawn card prefab on top of the deck
        currentDrawnCard = Instantiate(drawnCardPrefab, transform.position + Vector3.up, transform.rotation);
        initialDrawnCardPosition = currentDrawnCard.transform.position;

        // Optionally, you can set the position, rotation, or any other properties of the drawn card here.
        Debug.Log("Card drawn and instantiated on top of the deck!");

        return currentDrawnCard;
    }

    void Update()
    {

        // Check if the position of the drawn card has changed
        if (Vector3.Distance(currentDrawnCard.transform.position, initialDrawnCardPosition) > 0.01f)
        {
            Debug.Log("Card has been moved!");
            // Optionally, you can perform actions when the card has been moved.
            DrawCard();
        }

    }
}
