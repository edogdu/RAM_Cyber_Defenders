using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardInteraction : XRGrabInteractable
{
    public GameObject hiddenModel;
    private bool hasBeenPlaced = false;

    private void OnTriggerStay(Collider other)
    {
        if (!hasBeenPlaced && other.CompareTag("Socket"))
        {

            // Set the card's position and rotation to match the socket
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;

            // layer to "Nothing"
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
            interactionLayers = LayerMask.GetMask("Nothing");

            // Mark the card as placed
            hasBeenPlaced = true;

            ActivateHiddenModel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (hasBeenPlaced && other.CompareTag("Socket"))
        {
            // If the card was on the socket and is now removed, reset the flag
            hasBeenPlaced = false;

            HiddenModel();
        }
    }

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
