using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class DeckManager : MonoBehaviour
{
    public List<GameObject> cardPrefabs;
    private List<GameObject> deck = new List<GameObject>();
	
    public GameObject currentDrawnCard;
	
    private GameManager gameManager;
    [SerializeField] private AIPlayer aiplayer;
    public List<GameObject> reorrderDeck;

    //public int turnNumber = 0;

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

        for (int i = 0; i < deck.Count - 1; i++)
        {
            int randomNum = Random.Range(i, deck.Count);

            // Swap the cards at positions i and randomNum
            GameObject temp = deck[i];
            deck[i] = deck[randomNum];
            deck[randomNum] = temp;
        }

        reorrderDeck.AddRange(deck);
    }

    public GameObject DrawCard()
    {
        if (reorrderDeck.Count == 0)
        {
            Debug.LogWarning("Deck is empty!");
            StartCoroutine(waitTenSecond());
            return null;
        }

        GameObject drawnCardPrefab = reorrderDeck[0];
        reorrderDeck.RemoveAt(0);

        // Instantiate the drawn card prefab on top of the deck
        currentDrawnCard = Instantiate(drawnCardPrefab, transform.position + Vector3.up, transform.rotation);


        Debug.Log("Card drawn and instantiated on top of the deck!");
        if (gameManager.decidedTurn == 1)
        {
            currentDrawnCard.GetComponent<CardsInformation>().SetPlayer(1);
        }
        else
        {
            currentDrawnCard.GetComponent<CardsInformation>().SetPlayer(2);

        }
        aiplayer.aiTurn();
        return currentDrawnCard;
    }
    public GameObject GetTopCard
    {
        get { return currentDrawnCard; }
    }
    public int ReorderDeckCount
    {
        get { return reorrderDeck.Count; }
    }

    IEnumerator waitTenSecond()
    {
        yield return new WaitForSeconds(5);
        gameManager.determineWin();
    }

}
