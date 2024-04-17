using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
	[SerializeField] public GameObject Textbox;
    [SerializeField] public TextMeshProUGUI dialogue;
	
	void Speech (string CardString)
	{
		StartCoroutine(UpateTheTextBox(CardString));
	}
	
	IEnumerator UpateTheTextBox (string CardString)
	{
		Textbox.SetActive(true);
		dialogue.text = CardString;
		yield return new WaitForSeconds(2);
		Textbox.SetActive(false);
	}
}
