using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn()
	{
		SceneManager.LoadScene("SingleMode");
	}
	public void MenuBtn()
	{
		SceneManager.LoadScene("ThirdArrangement");
	}
	public void QuitBtn()
	{
		Application.Quit();
	}
}
