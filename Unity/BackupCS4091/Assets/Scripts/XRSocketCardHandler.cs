using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using System.Collections;

public class XRSocketCardHandler : XRSocketInteractor
{
    // Flag to indicate if the socket is occupied
    private bool isOccupied = false;

    void Update()
    {
        if (isOccupied)
        {
            // Assuming socketActive is a boolean variable in your class
            socketActive = false;
            Debug.LogWarning("Socket is now occupied!");
        }
        if(socketActive == false)
        {
            StartCoroutine(EnableColliderAfterDelay(10f));
            
        }
        
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        // Your logic for when an object is placed into the socket goes here
    }
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);

        // Check if the layer mask of the collider matches the layer mask of the socket
        int socketLayer = gameObject.layer;
        int colliderLayer = args.interactable.gameObject.layer;

        if (socketLayer != colliderLayer)
        {
            // Layers do not match, take appropriate action (e.g., disable collider)
                this.socketActive = false;
                this.allowHover = false;
                Debug.LogWarning("layers do not match!");
        }
        else
        {
            // Your logic for when an object is placed into the socket goes here
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

    private IEnumerator EnableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        socketActive = true;
        allowHover = true;
    }
}
