using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    [SerializeField] private GameObject cardPostion;
    [SerializeField] private GameObject cardPostion2;
    [SerializeField] private GameObject deckManagerGameObject;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private CardsInformation cardInfo;
    private GameObject[] blueSockets; // Store references to blue sockets
    private GameObject[] greenSockets; // Store references to green sockets
    private GameObject[] redSockets; // Store references to green sockets
    [SerializeField] private GameObject wastedDeck;
    public MessageWasted messageWasted;
    public float speed = 1.0f;
    private Vector3 targetPosition2;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        deckManager = FindObjectOfType<DeckManager>();
        blueSockets = GameObject.FindGameObjectsWithTag("BlueSocketPlayer2");
        greenSockets = GameObject.FindGameObjectsWithTag("GreenSocketPlayer2");
        redSockets = GameObject.FindGameObjectsWithTag("RedSocketPlayer2");
        Debug.Log("Number of blue sockets found: " + blueSockets.Length);
        targetPosition2 = cardPostion2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("AIPlayer Update called");
        deckManagerGameObject = deckManager.GetTopCard;
        cardInfo = deckManagerGameObject.GetComponent<CardsInformation>();
        //StartCoroutine(WaitToPlay());

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
        return null; // No available green socket found
    }

    GameObject FindFirstAvailableRedSocket(CardsInformation cardInfo)
    {

        redSockets = GameObject.FindGameObjectsWithTag("RedSocketPlayer2");
        Debug.Log("Number of red sockets found: " + redSockets.Length);
        foreach (GameObject socket in redSockets)
        {
            RedSocketPlayer2 socketHandler = socket.GetComponent<RedSocketPlayer2>();
            if (socketHandler != null  && (cardInfo.GetSymbol() == socketHandler.GetCardType() || cardInfo.GetSymbol() == 5) )
            {
                return socket;
            }
        }
        return null; // No available red socket found
    }

    void MoveCardToWasteDeck(GameObject card)
    {
        if (wastedDeck != null && card != null)
        {
            /*
            if (messageWasted != null)
            {
                messageWasted.increaseCount();
            }
            */
            card.transform.position = wastedDeck.transform.position;
        }
    }

    public void aiTurn()
    {
        StartCoroutine(WaitToPlay());
    }
    public IEnumerator WaitToPlay()
    {
        yield return new WaitForSeconds(2);
        if (cardInfo.GetPlayer() == 2)
        {
            Rigidbody rb = deckManagerGameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false; // Disable gravity
            }
            // Move the deckManagerGameObject towards targetPosition using Translate
            deckManagerGameObject.transform.position = targetPosition2;

            // Move the deckManagerGameObject towards targetPosition2 using Translate
            yield return new WaitForSeconds(5);
            Debug.LogError(Time.time);
            Debug.Log("Player 2's turn");
            Debug.LogError(cardInfo.GetColor());
            //this.interactionLayers = InteractionLayerMask.GetMask("Uninteractable");
            if (cardInfo.GetColor() == 1)
            {

                GameObject firstAvailableSocket = FindFirstAvailableBlueSocket();
                //got a blue card
                Debug.LogError("try to attach at " + firstAvailableSocket);
                if (firstAvailableSocket != null)
                {

                    deckManagerGameObject.transform.position = Vector3.Lerp(deckManagerGameObject.transform.position, firstAvailableSocket.transform.position, 0.1f);
                }
                else
                {
                    MoveCardToWasteDeck(deckManagerGameObject);
                }

            }
            else if (cardInfo.GetColor() == 2)
            {


                GameObject firstAvailableSocket = FindFirstAvailableGreenSocket(cardInfo);
                //got a green card
                if (firstAvailableSocket != null)
                {
                    deckManagerGameObject.transform.position = Vector3.Lerp(deckManagerGameObject.transform.position, firstAvailableSocket.transform.position, 0.1f);
                }
                else
                {
                    MoveCardToWasteDeck(deckManagerGameObject);
                }
            }
            else if (cardInfo.GetColor() == 3)
            {


                GameObject firstAvailableSocket = FindFirstAvailableRedSocket(cardInfo);
                //got a green card
                Debug.LogError("try to attach at " + firstAvailableSocket);
                if (firstAvailableSocket != null)
                {
                    deckManagerGameObject.transform.position = Vector3.Lerp(deckManagerGameObject.transform.position, firstAvailableSocket.transform.position, 0.1f);

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
        }

    }



}

