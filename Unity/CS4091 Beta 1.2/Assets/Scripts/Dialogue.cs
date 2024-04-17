using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
	[SerializeField] public GameObject Textbox;
    [SerializeField] public TextMeshProUGUI dialogue;
	
	void Speech (string a)
	{
		StartCoroutine(Text(a));
	}
	
	IEnumerator Text (string b)
	{
		//yield return new WaitForSeconds(1);
		Textbox.SetActive(true);
		dialogue.text = b;
		yield return new WaitForSeconds(2);
		Textbox.SetActive(false);
	}
}
