using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    [SerializeField] private GameObject deckManagerGameObject;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private CardsInformation cardInfo;
    private GameObject[] blueSockets; // Store references to blue sockets
    private GameObject[] greenSockets; // Store references to green sockets
    private GameObject[] redSockets; // Store references to green sockets
    [SerializeField] private GameObject wastedDeck;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        deckManager = FindObjectOfType<DeckManager>();
        blueSockets = GameObject.FindGameObjectsWithTag("BlueSocketPlayer2");
        greenSockets = GameObject.FindGameObjectsWithTag("GreenSocketPlayer2");
        redSockets = GameObject.FindGameObjectsWithTag("RedSocket");
        Debug.Log("Number of blue sockets found: " + blueSockets.Length);
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("AIPlayer Update called");
        deckManagerGameObject = deckManager.GetTopCard;
        cardInfo = deckManagerGameObject.GetComponent<CardsInformation>();
        
        if (cardInfo.GetPlayer() == 2)
        {
            
            Debug.Log("Player 2's turn");
            Debug.LogError(cardInfo.GetColor());
            if (cardInfo.GetColor() == 1)
            {
                GameObject firstAvailableSocket = FindFirstAvailableBlueSocket();
                //got a blue card
                Debug.LogError("try to attach at " + firstAvailableSocket);
                if (firstAvailableSocket != null)
                {
                    deckManagerGameObject.transform.position = firstAvailableSocket.transform.position;
                }
                else
                {
                    MoveCardToWasteDeck(deckManagerGameObject);
                }
               
            }
            else if(cardInfo.GetColor() == 2)
            {
                GameObject firstAvailableSocket = FindFirstAvailableGreenSocket(cardInfo);
                //got a green card
                Debug.LogError("try to attach at " + firstAvailableSocket);
                if (firstAvailableSocket != null)
                {
                    deckManagerGameObject.transform.position = firstAvailableSocket.transform.position;
                }
                else
                {
                    MoveCardToWasteDeck(deckManagerGameObject);
                }
            }
            else
            {
                MoveCardToWasteDeck(deckManagerGameObject);
            }
            

            //this.interactionLayers = InteractionLayerMask.GetMask("Uninteractable");

        }
    }

    GameObject FindFirstAvailableBlueSocket()
    {
        foreach (GameObject socket in blueSockets)
        {
            XRSocketCardHandler socketHandler = socket.GetComponent<XRSocketCardHandler>();
            if (socketHandler != null && !socketHandler.IsOccupied())
            {
                return socket;
            }
        }
        return null; // No available blue socket found
    }

    GameObject FindFirstAvailableGreenSocket(CardsInformation cardInfo)
    {
        greenSockets = GameObject.FindGameObjectsWithTag("GreenSocketPlayer2");
        Debug.Log("Number of green sockets found: " + greenSockets.Length);
        foreach (GameObject socket in greenSockets)
        {
            GreenSocketCardHandler socketHandler = socket.GetComponent<GreenSocketCardHandler>();
            if (socketHandler != null && !socketHandler.IsOccupied() && cardInfo.GetSymbol() == socketHandler.GetCardType())
            {
                return socket;
            }
        }
        return null; // No available blue socket found
    }
    void MoveCardToWasteDeck(GameObject card)
    {
        if (wastedDeck != null && card != null)
        {
            card.transform.position = wastedDeck.transform.position;
        }
    }

}

