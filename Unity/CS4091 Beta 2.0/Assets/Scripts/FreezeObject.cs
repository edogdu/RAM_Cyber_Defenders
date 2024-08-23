using UnityEngine;

public class FreezeObject : MonoBehaviour
{
    // Set these variables in the Unity Editor
    public bool freezePosition = true;
    public bool freezeRotation = true; 
    
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        // Save the initial position and rotation
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }
    void Update()
    {
        // Freeze position
        if (freezePosition)
        {
            transform.position = initialPosition;
        }

        // Freeze rotation
        if (freezeRotation)
        {
            transform.rotation = initialRotation;
        }
    }
}
