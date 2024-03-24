using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class GreenSocketCardHandler : XRSocketInteractor
{
    private DeckManager deckManager;
    private bool isInSocket = false;
    [SerializeField] private bool isOccupied = false;
    [SerializeField] private int WhatSymbolSocket = 0;
    [SerializeField] protected bool doFilterByType = true;

    protected override void Start()
    {
        deckManager = FindObjectOfType<DeckManager>();
    }

    void Update()
    {
        // Your Update logic here
        if (isOccupied == true)
        {
            this.interactionLayers = InteractionLayerMask.GetMask("Uninteractable");
        }
        else
        {
            this.interactionLayers = InteractionLayerMask.GetMask("Green");
        }
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
                
                return cardInfo.GetSymbol() == WhatSymbolSocket;
            }
        }
        return base.CanSelect(interactable);
    }
    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        base.OnSelectEntered(interactable);
        if (interactable is XRGrabInteractable)
        {
            XRGrabInteractable grabInteractable = interactable as XRGrabInteractable;
            if (CanSelect(grabInteractable))
            {
                isOccupied = true; // Object is now in the socket
                isInSocket = true;
                interactable.selectExited.AddListener(OnSelectExited);
            }
        }
    }

    protected override void OnSelectExited(XRBaseInteractable interactable)
    {
        base.OnSelectExited(interactable);
        isOccupied = false; // Object has left the socket
        isInSocket = false;
        interactable.selectExited.RemoveListener(OnSelectExited);
    }
}
