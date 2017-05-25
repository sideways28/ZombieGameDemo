using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public GameObject backButton; 
	public GameObject keyboardControls;
	
	public void OnStartButton()
	{
		Application.LoadLevel(2);
	}

	public void OnControlsButton()
	{
		keyboardControls.SetActive(true);
	}

	public void OnExitButton()
	{
		Application.Quit();
	}

	public void OnBackButton()
	{
		keyboardControls.SetActive(false);
	}
}
