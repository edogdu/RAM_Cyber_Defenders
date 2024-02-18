using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<GameObject> cardPrefabs;
    private List<GameObject> deck = new List<GameObject>();
    private GameObject currentDrawnCard;
    private Vector3 initialDrawnCardPosition;
    private GameManager gameManager;

    void Start()
    {
        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }

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

        Debug.Log("Card drawn and instantiated on top of the deck!");

        return currentDrawnCard;
    }

    void Update()
    {
        if (gameManager != null && Vector3.Distance(currentDrawnCard.transform.position, new Vector3(-1.98065519f, 1.43019998f, 0.378646255f)) > 2f)
        {
            // Now you can access public functions or variables of the GameManager
            gameManager.increaseTurn();
            DrawCard();
        }
        //if a turn end, draw a new card

    }
}
