using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FindAttachedCards : MonoBehaviour
{
    void Update()
    {
        // Find all objects with the tag "BlueCard"
        GameObject[] blueCards = GameObject.FindGameObjectsWithTag("Blue");

        // Iterate through each blue card
        foreach (GameObject card in blueCards)
        {
            // Check if the blue card has an XR grab interactor attached
            XRGrabInteractable grabInteractable = card.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null && grabInteractable.isSelected)
            {
                Debug.Log("Blue card attached: " + card.name);
                // You can perform any desired actions here, such as storing references or manipulating the attached blue cards
            }
        }
    }
}
