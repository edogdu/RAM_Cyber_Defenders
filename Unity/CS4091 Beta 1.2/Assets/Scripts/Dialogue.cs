using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
	[SerializeField] public GameObject Textbox;
    [SerializeField] public TextMeshProUGUI dialogue;
	
	[SerializeField] public DeckManager deckScript;
	
	public void Speech (string CardString)
	{
		StartCoroutine(UpateTheTextBox(CardString));
	}
	
	IEnumerator UpateTheTextBox (string CardString)
	{
		Textbox.SetActive(true);
		dialogue.text = CardString;
		yield return new WaitForSeconds(7);
		//Textbox.SetActive(false);
	}
	
	//Attempt at making the textbox appear and disapper per turn; might try this again later
	//void Update()
	//{
	//	if(deckScript.currentDrawnCard.GetComponent<CardsInformation>().GetPlayer() == 1)
	//	{
	//		Textbox.SetActive(true);
	//	}
	//	else
	//	{
	//		Textbox.SetActive(false);
	//	}
	//}
	
}
