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
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        deckManager = FindObjectOfType<DeckManager>();
        blueSockets = GameObject.FindGameObjectsWithTag("BlueSocketPlayer2");
        Debug.Log("Number of blue sockets found: " + blueSockets.Length);
    }

    // Update is called once per frame
    void Update()
    {
        deckManagerGameObject = deckManager.GetTopCard;
        cardInfo = deckManagerGameObject.GetComponent<CardsInformation>();

        if (cardInfo.GetPlayer() == '2')
        {
            foreach (GameObject blueSocket in blueSockets)
            {
                // Do something with each blue socket
                // For example, interact with them, check their state, etc.
                // blueSocket.GetComponent<YourComponent>().YourMethod();
            }
            //this.interactionLayers = InteractionLayerMask.GetMask("Uninteractable");

        }
    }
}

