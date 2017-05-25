using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public Texture NewGameGUI,NewGameGUI2,ControlsGUI,ControlsGUI2,QuitGUI,QuitGUI2; 

	private Texture NewGameIcon,ControlsIcon,QuitIcon;


	void Start()
	{
		NewGameIcon=NewGameGUI;
		ControlsIcon=ControlsGUI;
		QuitIcon=QuitGUI;
	}

	void OnGUI()
	{
		print ("NewGameIconSize : " + NewGameIcon.width + "/" + NewGameIcon.height);

		if(GUI.Button(new Rect(200,200,NewGameGUI.width,NewGameGUI.height), NewGameIcon))
		{
			Application.LoadLevel("GameScene");
		}
			

		if(GUI.Button(new Rect(200,328,ControlsGUI.width,ControlsGUI.height), ControlsIcon))
		{

		}
			
		if(GUI.Button(new Rect(200,456,QuitGUI.width,QuitGUI.height), QuitIcon))
		{
			Application.Quit();
		}
	}
	
}
