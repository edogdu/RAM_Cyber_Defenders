using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToCapsule : MonoBehaviour
{
    public Transform obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = obj.position;
    }
}
