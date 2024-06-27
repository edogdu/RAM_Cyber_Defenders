using UnityEngine;

public class CorrectingPostion : MonoBehaviour
{
    public GameObject table;
    public GameObject deck;

    private float tableY = 0.78f;
    private float ceilingY = 2.5f;
    private float tableUpX = 0.46f;
    private float tableDownX = -0.47f;
    private float tableLeftZ = 0.85f;
    private float tableRightZ = -0.93f;
    private void Start()
    {
        table = GameObject.FindGameObjectWithTag("Table");
        deck = GameObject.FindGameObjectWithTag("Deck");
    }
    void Update()
    {
        // Check if the card is below the deck
        if (transform.position.y < tableY)
        {
            // Move the card back to the top of the deck
            MoveToTopOfDeck();
        }
        // Check if the card is over the ceiling
        else if (transform.position.y > ceilingY)
        {
            // Move the card back to the top of the deck
            MoveToTopOfDeck();
        }
        // Check if the card is out of the table boundary in X-axis
        else if (transform.position.x > tableUpX || transform.position.x < tableDownX)
        {
            MoveToTopOfDeck();
        }
        // Check if the card is out of the table boundary in Z-axis
        else if (transform.position.z > tableLeftZ || transform.position.z < tableRightZ)
        {
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
