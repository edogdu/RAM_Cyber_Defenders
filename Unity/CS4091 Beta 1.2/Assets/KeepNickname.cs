using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class KeepNickname : MonoBehaviour
{
    [SerializeField] TMP_InputField nicknameInput;

    public void KeepNicknameAndMove()
    {
        string dataToKeep = nicknameInput.text;
        StaticData.valueToKeep = dataToKeep;
        SceneManager.LoadScene("2_Connecting");
    }

}
