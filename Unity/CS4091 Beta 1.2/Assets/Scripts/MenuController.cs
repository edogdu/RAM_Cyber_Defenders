using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn()
	{
		SceneManager.LoadScene("SecondRerrangement");
	}
	public void MenuBtn()
	{
		SceneManager.LoadScene("MainMenu");
	}
	public void QuitBtn()
	{
		Application.Quit();
	}
}
