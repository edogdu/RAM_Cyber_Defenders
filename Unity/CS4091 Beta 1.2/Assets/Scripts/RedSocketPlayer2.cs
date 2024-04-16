using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using System;
using System.Collections;

public class RedSocketPlayer2 : XRSocketInteractor
{
	public GameObject blueAnim;
	public GameObject greenAnim;
	public GameObject redAnim;
	
    private DeckManager deckManager;
    private bool isInSocket = false;
    [SerializeField] private bool isOccupied = false;
    [SerializeField] private int WhatSymbolSocket = 0;
    [SerializeField] protected bool doFilterByType = true;
    [SerializeField] private XRSocketCardHandler blueSocketHandler;
    [SerializeField] private GreenSocketCardHandler greenSocketHandler;
    private GameManager gameManager;
    [SerializeField] public GameObject attachedObject;
    [SerializeField] private GameObject blueAttachObject;
    [SerializeField] private GameObject greenAttachObject;

    protected override void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        deckManager = FindObjectOfType<DeckManager>();
        greenSocketHandler = greenSocketHandler.GetComponent<GreenSocketCardHandler>();
        blueSocketHandler = blueSocketHandler.GetComponent<XRSocketCardHandler>();

    }

    void Update()
    {
        // Your Update logic here

        blueAttachObject = blueSocketHandler.GetAttachedObject();
        greenAttachObject = greenSocketHandler.GetAttachedObject();

        WhatSymbolSocket = blueAttachObject.GetComponent<CardsInformation>().GetSymbol();
        
    }

    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void SetOccupied(bool value)
    {
        isOccupied = value;
    }

    public void SetCardType(int TypeInt)//1 for wifi 2 for...
    {
        WhatSymbolSocket = TypeInt;
    }

    public int GetCardType()
    {
        return WhatSymbolSocket;
    }

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        if (doFilterByType && interactable is MonoBehaviour interactableMonoBehaviour)
        {
            CardsInformation cardInfo = interactableMonoBehaviour.GetComponent<CardsInformation>();
            // Check if the card type matches the expected type
            if (cardInfo.GetSymbol() == 5)
            {
                return true;
            }
            return cardInfo.GetSymbol() == WhatSymbolSocket; // return true or false
        }
        return base.CanHover(interactable);
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        if (doFilterByType && interactable is MonoBehaviour interactableMonoBehaviour)
        {
            CardsInformation cardInfo = interactableMonoBehaviour.GetComponent<CardsInformation>();
            if (isOccupied == false)
            {
                // Check if the card type matches the expected type\
                if (cardInfo.GetSymbol() == 5)
                {
                    return true;
                }
                return cardInfo.GetSymbol() == WhatSymbolSocket;
            }
        }
        return base.CanSelect(interactable);
    }
    [Obsolete]
    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        attachedObject = interactable.gameObject;
        if (attachedObject.tag == "RedCard")
        {
            gameManager.switchTurn();
            deckManager.DrawCard();
            StartCoroutine(WaitAndDestroyPlayer1()); // Start the coroutine
        }

        base.OnSelectEntered(interactable);
        if (interactable is XRGrabInteractable)
        {
            XRGrabInteractable grabInteractable = interactable as XRGrabInteractable;
            if (CanSelect(grabInteractable))
            {
                isOccupied = true; // Object is now in the socket
                isInSocket = true;
                attachedObject.transform.position = transform.position;
                attachedObject.transform.rotation = transform.rotation;
                interactable.selectExited.AddListener(OnSelectExited);
            }
        }
    }
    [Obsolete]
    protected override void OnSelectExited(XRBaseInteractable interactable)
    {
        base.OnSelectExited(interactable);
        isOccupied = false; // Object has left the socket
        isInSocket = false;
        interactable.selectExited.RemoveListener(OnSelectExited);
    }

    IEnumerator WaitAndDestroyPlayer1()
    {
		blueAnim.SetActive(false);
		redAnim.SetActive(true);
        yield return new WaitForSeconds(2);
        Debug.Log("Finished waiting for 2 seconds");
        if(greenSocketHandler.isObjectAttached == true)
        {
			greenAnim.SetActive(true);
            Destroy(attachedObject);
            Destroy(greenAttachObject);
			redAnim.SetActive(false);
			yield return new WaitForSeconds(1);
			greenAnim.SetActive(false);
            
        }
        else
        {
			blueAnim.SetActive(true);
            Destroy(attachedObject);
            Destroy(blueAttachObject);
			redAnim.SetActive(false);
			yield return new WaitForSeconds(1);
			blueAnim.SetActive(false);
        }
		
		
    }

}
