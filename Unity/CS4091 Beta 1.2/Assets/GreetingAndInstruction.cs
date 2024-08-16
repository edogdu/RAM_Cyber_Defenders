using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GreetingAndInstruction : MonoBehaviour
{
    public TMP_Text nameAndInstruction;
    [SerializeField] TMP_Text nickname;

    public void Start()
    {
        string nickname = StaticData.valueToKeep;

        nameAndInstruction.text = "Hello, " + nickname + "!";
    }
}
