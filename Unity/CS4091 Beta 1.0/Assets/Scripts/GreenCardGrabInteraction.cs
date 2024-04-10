using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GreenCardGrabInteraction : XRGrabInteractable
{
    public GameObject hiddenModel;
    private bool hasBeenPlaced = false;
    private GreenSocketCardHandler currentSocket; // Keep track of the current socket
    private Rigidbody rb;
    private CardsInformation cardInfo;
    private GameManager gameManager;
    private DeckManager deckManager;
    //private XRSocketCardHandler greenSocketHandler;
    //private XRSocketCardHandler redSocketHandler;
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
        if (this.gameObject.tag == "GreenCard")
        {
            if (!hasBeenPlaced && args.interactorObject is XRSocketInteractor)
            {
                XRSocketInteractor socketInteractor = args.interactorObject as XRSocketInteractor;
                //this is for the waste socket
                if (socketInteractor.gameObject.tag == "wasteSocket")
                {
                    gameManager.switchTurn();
                    deckManager.DrawCard();
                    Destroy(gameObject);
                    return;
                }

                GreenSocketCardHandler socket = socketInteractor.GetComponent<GreenSocketCardHandler>();
                if (socket == null)
                {
                    Debug.LogWarning("GreenSocketCardHandler component not found on socket!");
                    return;
                }

                Debug.LogWarning("Green Card");
                // Check if the socket is occupied
                //if (socket != null && socket.IsOccupied() == false && socket.GetCardType() == cardInfo.GetSymbol() && gameObject.layer == socketInteractor.gameObject.layer)
                //{
                // Set the card's position and rotation to match the socket
                if (socketInteractor.gameObject.tag == "GreenSocket" || socketInteractor.gameObject.tag == "GreenSocketPlayer2")
                {
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
