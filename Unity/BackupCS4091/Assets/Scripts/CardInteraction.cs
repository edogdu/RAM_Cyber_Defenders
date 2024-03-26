
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class oldCardInteraction : XRGrabInteractable
{
    public GameObject hiddenModel;
    private bool hasBeenPlaced = false;
    private XRSocketCardHandler currentSocket; // Keep track of the current socket
    private Rigidbody rb;
    private CardsInformation cardInfo;
    private GameManager gameManager;
    private DeckManager deckManager;
    private XRSocketCardHandler greenSocketHandler;
    private XRSocketCardHandler redSocketHandler;
    //private CardsInformation cardInfo;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        cardInfo = GetComponent<CardsInformation>();
        deckManager = FindObjectOfType<DeckManager>();
    }
    
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if (!hasBeenPlaced && args.interactorObject is XRSocketInteractor)
        {
            XRSocketInteractor socketInteractor = args.interactorObject as XRSocketInteractor;
            //this is for the waste socket
            if(socketInteractor.gameObject.name == "wasteSocket")
            {
                Debug.LogWarning("this is destroy");
                gameManager.switchTurn();
                deckManager.DrawCard();
                Destroy(gameObject);
                return;
            }
            XRSocketCardHandler socket = socketInteractor.GetComponent<XRSocketCardHandler>();
            GameObject greenSocket = socket.GetGreenSocket();
            GameObject redSocket = socket.GetRedSocket();
            greenSocketHandler = greenSocket.GetComponent<XRSocketCardHandler>();
            redSocketHandler = redSocket.GetComponent<XRSocketCardHandler>();
            if (cardInfo.GetColor() == 2)
            {
                Debug.LogWarning("Green Card");
                // Check if the type of the green socket matches the card's symbol
                if (greenSocketHandler != null && greenSocketHandler.GetCardType() == cardInfo.GetSymbol())
                {
                    // Place the card into the socket
                    // Add logic here for placing the card into the green socket
                    this.interactionLayers = InteractionLayerMask.GetMask("Uninteractable");
                }
                else
                {
                    Debug.LogWarning("Card type does not match the green socket.");
                    greenSocketHandler.allowSelect = false;
                    // Add logic here for disallowing the placement of the card into the green socket
                }
            }
            if (cardInfo.GetColor() == 1) //blue card  logic below
            {
                Debug.LogWarning("BlueCard");
                // Check if the socket is occupied
                if (socket != null && socket.IsOccupied() == false && gameObject.layer == socketInteractor.gameObject.layer)
                {
                    // Set the card's position and rotation to match the socket
                    this.transform.position = socketInteractor.transform.position;
                    this.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                    this.interactionLayers = InteractionLayerMask.GetMask("Uninteractable");
                    // Mark the card as placed
                    hasBeenPlaced = true;
                    socket.SetOccupied(true);
                    // Mark the socket as occupied and store a reference to the current socket
                    socket.SetCardType(cardInfo.GetSymbol());
                    currentSocket = socket;
                    gameManager.switchTurn();
                    deckManager.DrawCard();
                    ActivateHiddenModel();
                    rb = GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.constraints = RigidbodyConstraints.FreezeAll;
                        //rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                        //rb.constraints = RigidbodyConstraints.FreezeRotation;
                        //rb.constraints = RigidbodyConstraints.FreezeScale;
                    }
                }
            }

            if (cardInfo.GetColor() == 3)
            {
                Debug.LogWarning("Red Card");
                // Check if the type of the red socket matches the card's symbol
                if (redSocketHandler != null && redSocketHandler.GetCardType() == cardInfo.GetSymbol())
                {
                    // Place the card into the socket
                    // Add logic here for placing the card into the red socket
                    this.interactionLayers = InteractionLayerMask.GetMask("Uninteractable");
                }
                else
                {
                    Debug.LogWarning("Card type does not match the red socket.");
                    // Add logic here for disallowing the placement of the card into the red socket

                }
            }
        }
    }

    /*
    private void OnSelectExited(SelectExitEventArgs args)
    {
        if (hasBeenPlaced && args.interactor is XRSocketInteractor)
        {
            XRSocketInteractor socketInteractor = args.interactor as XRSocketInteractor;

            // If the card was on the socket and is now removed, reset the flag
            hasBeenPlaced = false;

            // Reset the socket occupancy status
            if (currentSocket != null)
            {
                currentSocket.SetOccupied(false);
                currentSocket = null;
            }

            HiddenModel();
        }
    }
    */

    private void ActivateHiddenModel()
    {
        if (hiddenModel != null)
        {
            hiddenModel.SetActive(true);
            Debug.Log("Hidden model activated!");
        }
    }

    private void HiddenModel()
    {
        if (hiddenModel != null)
        {
            hiddenModel.SetActive(false);
            Debug.Log("Hidden model hidden!");
        }
    }

}
