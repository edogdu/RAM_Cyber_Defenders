using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ClickingWasted : MonoBehaviour
{
    public TMP_Text abandonedDecktext;
    public int WastedCards = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            WastedCards++;
            if (WastedCards >= 50)
                WastedCards = 50;
            abandonedDecktext.text = "Wasted Card: " + WastedCards;
        }

    }
}
