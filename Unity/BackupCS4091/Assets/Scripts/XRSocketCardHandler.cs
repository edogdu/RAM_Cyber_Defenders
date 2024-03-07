using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

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
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        // Your logic for when an object is placed into the socket goes here
    }

    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void SetOccupied(bool value)
    {
        isOccupied = value;
    }
}
