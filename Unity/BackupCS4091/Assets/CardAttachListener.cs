using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using System;
using System.Collections;

public class CardAttachListener : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    [Obsolete]
    void Start()
    {
        // Get the XRGrabInteractable component attached to this GameObject
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to the OnSelectEntered event
        if (grabInteractable != null)
        {
            grabInteractable.onSelectEntered.AddListener(OnCardAttached);
        }
    }

    [Obsolete]
    void OnDestroy()
    {
        // Unsubscribe from the event to prevent memory leaks
        if (grabInteractable != null)
        {
            grabInteractable.onSelectEntered.RemoveListener(OnCardAttached);
        }
    }

    // Event handler for when a card is attached
    void OnCardAttached(XRBaseInteractor interactor)
    {
        // Check if the attached object is a blue card
        if (gameObject.CompareTag("BlueCard"))
        {
            Debug.Log("Blue card attached: " + gameObject.name);

            // You can perform any desired actions here when a blue card is attached,
            // such as triggering effects, updating UI, or executing custom logic.
        }
        if (gameObject.CompareTag("BlueSocket"))
        {
            Debug.Log("Blue card attached: " + gameObject.name);

            // You can perform any desired actions here when a blue card is attached,
            // such as triggering effects, updating UI, or executing custom logic.
        }
    }
}
