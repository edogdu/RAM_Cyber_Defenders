using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RedCardGrabInteraction : XRGrabInteractable
{
    public GameObject hiddenModel;
    private bool hasBeenPlaced = false;
    private RedSocketCardHandler currentSocket; // Keep track of the current socket
    private Rigidbody rb;
    private CardsInformation cardInfo;
    private GameManager gameManager;
    private DeckManager deckManager;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        cardInfo = GetComponent<CardsInformation>();
        deckManager = FindObjectOfType<DeckManager>();

        if(cardInfo.GetPlayer() == 1)
        {
            this.interactionLayers = InteractionLayerMask.GetMask("Red");
        }
        else if(cardInfo.GetPlayer() == 2)
        {
            this.interactionLayers = InteractionLayerMask.GetMask("Uninteractable");
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if (this.gameObject.tag == "RedCard")
        {
            if (!hasBeenPlaced && args.interactorObject is XRSocketInteractor)
            {
                XRSocketInteractor socketInteractor = args.interactorObject as XRSocketInteractor;
                //this is for the waste socket
                if (socketInteractor.gameObject.tag == "wasteSocket")
                {
                    Debug.LogWarning("this is destroy");
                    gameManager.switchTurn();
                    deckManager.DrawCard();
                    Destroy(gameObject);
                    return;
                }
                RedSocketCardHandler socket = socketInteractor.GetComponent<RedSocketCardHandler>();
                if (socket == null)
                {
                    Debug.LogWarning("RedSocketCardHandler component not found on socket!");
                    return;
                }
                Debug.LogWarning("Red Card");
                //if (socket.IsOccupied() == false && socket.GetCardType() == cardInfo.GetSymbol() && gameObject.layer == socketInteractor.gameObject.layer)
                if (socketInteractor.gameObject.tag == "RedSocket")
                {
                    Debug.LogWarning("Red Card Placed");
                    // Set the card's position and rotation to match the socket
                    this.transform.position = socketInteractor.transform.position;
                    this.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                    //this.interactionLayers = InteractionLayerMask.GetMask("Uninteractable");
                    // Mark the card as placed
                    hasBeenPlaced = true;
                    socket.SetOccupied(true);
                    // Mark the socket as occupied and store a reference to the current socket
                    socket.SetCardType(cardInfo.GetSymbol());
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
            //Debug.Log("Hidden model activated!");
        }
    }

	/*
    private void HiddenModel()
    {
        if (hiddenModel != null)
        {
            hiddenModel.SetActive(false);
            Debug.Log("Hidden model hidden!");
        }
    }
	*/
}
