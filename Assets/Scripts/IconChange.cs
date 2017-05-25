using UnityEngine;
using System.Collections;

public class IconChange : MonoBehaviour {

	public Texture DefaultTexture,OnMouseTexture,ControlMenu,AboutTexture,Back;
	bool ShowControls = false;
	bool About = false;
	void OnGUI()
	{
		if(ShowControls)
		{
		GUI.DrawTexture(new Rect(300,0,ControlMenu.width,ControlMenu.height),ControlMenu,ScaleMode.ScaleToFit);
		
			if(GUI.Button(new Rect(0,0,Back.width,Back.height),Back))
			   {
				ShowControls=false;
			   }
		}
		if(About)
		{
			GUI.DrawTexture(new Rect(300,0,AboutTexture.width,AboutTexture.height),AboutTexture,ScaleMode.ScaleToFit);
			
			if(GUI.Button(new Rect(0,0,Back.width,Back.height),Back))
			{
				About=false;
			}
		}
	}

	void OnMouseEnter()
	{
		//print (gameObject.name);
		GetComponent<GUITexture>().texture = OnMouseTexture;
	}
	void OnMouseExit()
	{
		GetComponent<GUITexture>().texture = DefaultTexture;
	}

	void OnMouseUp()
	{
		if(gameObject.name=="Start")
		{
			Application.LoadLevel("GameScene");
		}
		if(gameObject.name=="Controls")
		{
			ShowControls=true;
		}
		if(gameObject.name=="Exit")
		{
			Application.Quit();
		}
		if(gameObject.name=="About")
		{
			About=true;
		}
	}
}
