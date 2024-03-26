using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberAttackAnimation : MonoBehaviour
{
    public GameObject red;
    public GameObject something;
    public float speed;
    public GameObject mainCamera;
    public GameObject main1Target;
    public GameObject main2Target;
    public float speed2;
    public float speed3;
    public GameObject passingObject;

    public GameObject destination;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        red.transform.position = Vector3.MoveTowards(red.transform.position, something.transform.position, speed);

        if (red.transform.position.x >= passingObject.transform.position.x)
        {
            firstAnimation();
        }
        if (red.transform.position == something.transform.position)
        {
            secondAnimation();
        }
    }

    void firstAnimation()
    {
        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, main1Target.transform.position, speed2);
        mainCamera.transform.rotation = Quaternion.Euler(0f, 45f, 0f);
    }

    void secondAnimation()
    {
        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, main2Target.transform.position, speed2);
        mainCamera.transform.rotation = Quaternion.Euler(0f, 40f, -15f);
        red.transform.position = Vector3.MoveTowards(red.transform.position, destination.transform.position, speed3);
        something.transform.position = Vector3.MoveTowards(something.transform.position, destination.transform.position, speed3);
    }


}
