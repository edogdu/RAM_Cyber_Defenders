using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BlueCardGrabInteraction : XRGrabInteractable
{
    public GameObject hiddenModel;
	public GameObject hiddenModel2;
    private bool hasBeenPlaced = false;
    public XRSocketCardHandler currentSocket; // Keep track of the current socket
	//private GreenSocketCardHandler greenSocket;
	private GameObject currentGreenSocket;
    private Rigidbody rb;
    private CardsInformation cardInfo;
    private GameManager gameManager;
    private DeckManager deckManager;
	
	private int socketNumber = 0;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        cardInfo = GetComponent<CardsInformation>();
        deckManager = FindObjectOfType<DeckManager>();
    }

	void Update()
	{
		if(hasBeenPlaced == true)
		{
			if(currentGreenSocket.GetComponent<GreenSocketCardHandler>().IsOccupied() == true)
			{
				hiddenModel.SetActive(false);
				hiddenModel2.SetActive(true);
			}
			else
			{
				hiddenModel.SetActive(true);
				hiddenModel2.SetActive(false);
			}
		}
		else
		{
			hiddenModel.SetActive(false);
			hiddenModel2.SetActive(false);
		}
	}

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
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
            XRSocketCardHandler socket = socketInteractor.GetComponent<XRSocketCardHandler>();
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
				
				// Find the corresponding green socket
				// This method is pretty inefficient, but it works
				
				string socketName = currentSocket.ToString();
				char name = socketName[8];
				socketNumber = name - '0';
				
				if(name != 'P')
				{
					if(name == '1')
					{
						currentGreenSocket = GameObject.Find("G_socket1");
					}
					else if(name == '2')
					{
						currentGreenSocket = GameObject.Find("G_socket2");
					}
					else if(name == '3')
					{
						currentGreenSocket = GameObject.Find("G_socket3");
					}
					else if(name == '4')
					{
						currentGreenSocket = GameObject.Find("G_socket4");
					}
					else if(name == '5')
					{
						currentGreenSocket = GameObject.Find("G_socket5");
					}
					else if(name == '6')
					{
						currentGreenSocket = GameObject.Find("G_socket6");
					}
					else if(name == '7')
					{
						currentGreenSocket = GameObject.Find("G_socket7");
					}
					else if(name == '8')
					{
						currentGreenSocket = GameObject.Find("G_socket8");
					}
				}
				else
				{
					name = socketName[9];
					socketNumber = name - '0';
					if(name == '1')
					{
						currentGreenSocket = GameObject.Find("G_socketP1");
					}
					else if(name == '2')
					{
						currentGreenSocket = GameObject.Find("G_socketP2");
					}
					else if(name == '3')
					{
						currentGreenSocket = GameObject.Find("G_socketP3");
					}
					else if(name == '4')
					{
						currentGreenSocket = GameObject.Find("G_socketP4");
					}
					else if(name == '5')
					{
						currentGreenSocket = GameObject.Find("G_socketP5");
					}
					else if(name == '6')
					{
						currentGreenSocket = GameObject.Find("G_socketP6");
					}
					else if(name == '7')
					{
						currentGreenSocket = GameObject.Find("G_socketP7");
					}
					else if(name == '8')
					{
						currentGreenSocket = GameObject.Find("G_socketP8");
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
        }
    }

    
    /*private void HiddenModel()
    {
        if (hiddenModel != null)
        {
            hiddenModel.SetActive(false);
            Debug.Log("Hidden model hidden!");
        }
    }*/

}
