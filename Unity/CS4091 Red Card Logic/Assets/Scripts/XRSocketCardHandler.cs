using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using System;

public class XRSocketCardHandler : XRSocketInteractor
{
    [SerializeField] private GameObject GreenSocket;
    [SerializeField] private GameObject RedSocket;
    private DeckManager deckManager;
    [SerializeField] private GreenSocketCardHandler greenSocketHandler;
    [SerializeField] private XRSocketCardHandler redSocketHandler;
    [SerializeField] private bool isOccupied = false;
    [SerializeField] private int WhatSymbolSocket = 0;
    [SerializeField] protected bool doFilterByType = true;

    protected override void Start()
    {
        greenSocketHandler = GreenSocket.GetComponent<GreenSocketCardHandler>();
        redSocketHandler = RedSocket.GetComponent<XRSocketCardHandler>();

        deckManager = FindObjectOfType<DeckManager>();
    }

    void Update()
    {
        // Your Update logic here
        if(isOccupied == true)
        {
            this.interactionLayers = InteractionLayerMask.GetMask("Uninteractable");
        }
        else
        {
            this.interactionLayers = InteractionLayerMask.GetMask("Blue");
        }
    }

    /*
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        // Show hover material only if the object matches the filter type
        IXRHoverInteractable hoverInteractable = args.interactable;
        if (CanHover(hoverInteractable))
        {
          
        }
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        // Your logic for when an object exits the hover state goes here
    }
    */
    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void SetOccupied(bool value)
    {
        isOccupied = value;
    }

    public void ActivateSocket()
    {
        if (GreenSocket != null)
            GreenSocket.SetActive(true);

        if (RedSocket != null)
            RedSocket.SetActive(true);
    }

    public void DeactivateSocket()
    {
        if (GreenSocket != null)
            GreenSocket.SetActive(false);

        if (RedSocket != null)
            RedSocket.SetActive(false);
    }

    public void SetCardType(int TypeInt)//1 for wifi 2 for...
    {
        WhatSymbolSocket = TypeInt;

        greenSocketHandler.SetCardType(TypeInt);

        if (redSocketHandler != null)
        {
            redSocketHandler.SetCardType(TypeInt);
        }
        else
        {
            //Debug.LogWarning("XRSocketCardHandler component not found on RedSocket!");
        }
    }

    public int GetCardType()
    {
        return WhatSymbolSocket;
    }

    public GameObject GetGreenSocket()
    {
        return GreenSocket;
    }

    public GameObject GetRedSocket()
    {
        return RedSocket;
    }

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        if (doFilterByType && interactable is MonoBehaviour interactableMonoBehaviour)
        {
            CardsInformation cardInfo = interactableMonoBehaviour.GetComponent<CardsInformation>();
                // Check if the card type matches the expected type
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
                    SetOccupied(true);
                    return cardInfo.GetSymbol() == WhatSymbolSocket;
                }
        }
        return base.CanSelect(interactable);
    }
    [Obsolete]
    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        base.OnSelectEntered(interactable);
        ActivateSocket();
        SetCardType(WhatSymbolSocket);
        // Subscribe to the selectExited event
        interactable.selectExited.AddListener(OnSelectExited);
    }
    [Obsolete]
    protected override void OnSelectExited(XRBaseInteractable interactable)
    {
        Debug.Log("Object detached from the socket.");
        isOccupied = false;
        DeactivateSocket();
        // Unsubscribe from the selectExited event
        interactable.selectExited.RemoveListener(OnSelectExited);
    }

}
