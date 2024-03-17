using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class XRSocketCardHandler : XRSocketInteractor
{
    [SerializeField] private GameObject GreenSocket;
    [SerializeField] private GameObject RedSocket;
    private DeckManager deckManager;
    private XRSocketCardHandler greenSocketHandler;
    private XRSocketCardHandler redSocketHandler;
    private bool isOccupied = false;
    private int WhatTypeSocket = 0;
    [SerializeField] protected bool doFilterByType = true;

    protected override void Start()
    {
        greenSocketHandler = GreenSocket.GetComponent<XRSocketCardHandler>();
        redSocketHandler = RedSocket.GetComponent<XRSocketCardHandler>();
        deckManager = FindObjectOfType<DeckManager>();
    }

    void Update()
    {
        // Your Update logic here
    }
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

    public void SetCardType(int TypeInt)
    {
        WhatTypeSocket = TypeInt;

        if (greenSocketHandler != null)
        {
            greenSocketHandler.SetCardType(TypeInt);
        }
        else
        {
            Debug.LogWarning("XRSocketCardHandler component not found on GreenSocket!");
        }

        if (redSocketHandler != null)
        {
            redSocketHandler.SetCardType(TypeInt);
        }
        else
        {
            Debug.LogWarning("XRSocketCardHandler component not found on RedSocket!");
        }
    }

    public int GetCardType()
    {
        return WhatTypeSocket;
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
            if (cardInfo != null)
            {
                // Check if the card type matches the expected type
                return cardInfo.GetSymbol() == WhatTypeSocket;
            }
        }
        return base.CanHover(interactable);
    }
    
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        if (doFilterByType && interactable is MonoBehaviour interactableMonoBehaviour)
        {
            CardsInformation cardInfo = interactableMonoBehaviour.GetComponent<CardsInformation>();
            if (cardInfo != null)
            {
                // Check if the card type matches the expected type\
                return cardInfo.GetSymbol() == WhatTypeSocket;
            }
        }
        return base.CanSelect(interactable);
    }

    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        deckManager.DrawCard();
    }

}
