using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardAttachListener : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // Get the XRGrabInteractable component attached to this GameObject
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to the OnSelectEntered event
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnCardAttached);
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the event to prevent memory leaks
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnCardAttached);
        }
    }

    // Event handler for when a card is attached
    void OnCardAttached(SelectEnterEventArgs args)
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
        if (gameObject.CompareTag("GreenCard"))
        {
            Debug.Log("Green card attached: " + gameObject.name);

            // You can perform any desired actions here when a blue card is attached,
            // such as triggering effects, updating UI, or executing custom logic.
        }
        if (gameObject.CompareTag("GreenSocket"))
        {
            Debug.Log("Green card attached: " + gameObject.name);

            // You can perform any desired actions here when a blue card is attached,
            // such as triggering effects, updating UI, or executing custom logic.
        }
    }
}
