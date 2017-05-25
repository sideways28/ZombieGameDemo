using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

	public GameObject Player;
	bool DoorisOpen;
	float Angle = 0.0f;
	float RotationSpeed=100;
	bool RotateUp,RotateDown;

	void Start()
	{
		RotateUp=false;
		RotateDown=false;
		DoorisOpen = false;
	}

	void Update () 
	{
		Angle = Mathf.Clamp( Angle, 0, 85 );

		float dist = Vector3.Distance(transform.position, Player.transform.position);

		if(RotateUp)
		{
			transform.eulerAngles = Vector3.up*Angle;
			Angle+=Time.deltaTime*RotationSpeed;
		}
		if(RotateDown)
		{
			transform.eulerAngles = Vector3.up*Angle;
			Angle-=Time.deltaTime*RotationSpeed;
		}

		if(Angle>0)
		{
			DoorisOpen=true;
		}
		if(Angle<1)
		{
			DoorisOpen=false;
		}

		if(Input.GetKeyDown(KeyCode.E)&&dist<3)
		{
			if(!DoorisOpen)
			{
				RotateUp=true;
				RotateDown=false;
			}
			else if(DoorisOpen)
			{
				RotateDown=true;
				RotateUp=false;
			}
		}
		if(dist>10 && RotateUp)
		{
			RotateDown=true;
			RotateUp=false;
		}
	}
}
