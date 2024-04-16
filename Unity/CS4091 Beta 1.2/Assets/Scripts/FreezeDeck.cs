using UnityEngine;

public class FreezeDeck : MonoBehaviour
{
    // Set these variables in the Unity Editor
    public bool freezePosition = true;
    public bool freezeRotation = true;

    void Update()
    {
        // Freeze position
        if (freezePosition)
        {
            transform.position = transform.position;
        }

        // Freeze rotation
        if (freezeRotation)
        {
            transform.rotation = transform.rotation;
        }
    }
}