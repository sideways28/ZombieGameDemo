using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {

	public GameObject deathButtons;

	void Start()
	{
		deathButtons.SetActive(false);		
	}

	public void OnRetryButton()
	{
		Application.LoadLevel("GameScene");
	}

	public void OnExitButton()
	{
		Application.Quit();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(deathButtons)
			{
				deathButtons.SetActive(false);
			}
			else 
			{
				deathButtons.SetActive(true);
			}
		}
	}		
	
}
