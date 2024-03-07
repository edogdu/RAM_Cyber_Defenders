using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardInteraction : XRGrabInteractable
{
    public GameObject hiddenModel;
    private bool hasBeenPlaced = false;
    private XRSocketCardHandler currentSocket; // Keep track of the current socket
    private Rigidbody rb;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        
        if (!hasBeenPlaced && args.interactorObject is XRSocketInteractor)
        {
            XRSocketInteractor socketInteractor = args.interactorObject as XRSocketInteractor;

            // Check if the socket is occupied
            XRSocketCardHandler socket = socketInteractor.GetComponent<XRSocketCardHandler>();
            if (socket != null && !socket.IsOccupied())
            {
                // Set the card's position and rotation to match the socket
                this.transform.position = socketInteractor.transform.position;
                this.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                this.interactionLayers = InteractionLayerMask.GetMask("Uninteractable");
                Debug.Log($"Card placed at position: {transform.position}");
                Debug.Log($"Card rotated to rotation: {transform.rotation.eulerAngles}");
                Debug.Log($"Interaction layers set to: {this.interactionLayers.value}");
                // Mark the card as placed
                hasBeenPlaced = true;

                // Mark the socket as occupied and store a reference to the current socket
                socket.SetOccupied(true);
                currentSocket = socket;

                ActivateHiddenModel();
                Debug.Log("touch");
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

    private void DetermineTurn()
    {
        // Base on the turn, give it a player1side or player2side layer mask
        // This is used for red card
    }
}
