using UnityEngine;

public class CorrectingPostion : MonoBehaviour
{
    public GameObject table;
    public GameObject deck;
    private void Start()
    {
        table = GameObject.FindGameObjectWithTag("Table");
        deck = GameObject.FindGameObjectWithTag("Deck");
    }
    void Update()
    {
        // Check if the card is below the deck
        if (transform.position.y < table.transform.position.y)
        {
            // Move the card back to the top of the deck
            MoveToTopOfDeck();
        }
    }

    void MoveToTopOfDeck()
    {
        // Ensure the deck reference is not null
        if (deck != null)
        {
            // Calculate the position on top of the deck
            Vector3 topOfDeckPosition = deck.transform.position;

            // Set the card's position to the calculated position
            transform.position = topOfDeckPosition;
        }
        else
        {
            Debug.LogError("Deck reference is null!");
        }
    }

}
