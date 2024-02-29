using System.Collections.Generic;
using UnityEngine;
using CustomUnitySpace;

public class DeckManager : MonoBehaviour
{
    public List<GameObject> cardPrefabs;
    // private List<GameObject> deck = new List<GameObject>();
    private GameObject currentDrawnCard;
    private Vector3 initialDrawnCardPosition;
    private GameManager gameManager;

    public List<GameObject> reorrderDeck;

    public int turnNumber = 0;

    void Start()
    {
        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }

        ShuffleCards shuffle = new ShuffleCards();
        reorrderDeck = shuffle.InitializeDeck(cardPrefabs);

        DrawCard();
    }

    /*void InitializeDeck()
    {
        deck.AddRange(cardPrefabs);

        for (int i = 0; i < deck.Count - 1; i++)
        {
            int randomNum = Random.Range(i, deck.Count);

            // Swap the cards at positions i and randomNum
            GameObject temp = deck[i];
            deck[i] = deck[randomNum];
            deck[randomNum] = temp;
        }

        reorrderDeck.AddRange(deck);
    }*/ // -> moved to CustomLibrary

    public GameObject DrawCard()
    {
        if (reorrderDeck.Count == 0)
        {
            Debug.LogWarning("Deck is empty!");
            return null;
        }

        GameObject drawnCardPrefab = reorrderDeck[0];
        reorrderDeck.RemoveAt(0);

        // Instantiate the drawn card prefab on top of the deck
        currentDrawnCard = Instantiate(drawnCardPrefab, transform.position + Vector3.up, transform.rotation);
        initialDrawnCardPosition = currentDrawnCard.transform.position;

        Debug.Log("Card drawn and instantiated on top of the deck!");

        return currentDrawnCard;
    }

    void Update()
    {
        if (gameManager != null && Vector3.Distance(currentDrawnCard.transform.position, new Vector3(-1.58700001f, 1.43499994f, -1.31700003f)) > 2f)
        {
            // Now you can access public functions or variables of the GameManager
            gameManager.increaseTurn();
            DrawCard();
        }

        //if a turn ends, draw a new card
        //placing the card on the board is considered to be the end of the turn
        if (
            currentDrawnCard.transform.position.z < 0.44 && currentDrawnCard.transform.position.z > -0.50 &&
            currentDrawnCard.transform.position.x < 0.30 && currentDrawnCard.transform.position.x > -0.40 &&
            currentDrawnCard.transform.position.y < 0.83 && currentDrawnCard.transform.position.y > 0.80
        )
        {
            turnNumber++;
        }
    }

    public int ReorderDeckCount
    {
        get { return reorrderDeck.Count; }
    }

}
