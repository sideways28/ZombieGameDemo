using UnityEngine;
using System.Collections;

public class TS_CameraMode : MonoBehaviour {

	public Camera firstPersonCam;
	public Camera thirdPersonCam;

	private float camTransformSpeed = 1f; 

	public enum CameraMode
	{
		firstPerson,
		thirdPerson
	};

	public static CameraMode currentCamMode;

	void Start()
	{
		currentCamMode = CameraMode.firstPerson;
		thirdPersonCam.GetComponent<Camera>().enabled = false;
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
			if(currentCamMode == CameraMode.thirdPerson)
			{
				currentCamMode = CameraMode.firstPerson;
			}
			else
			{
				currentCamMode = CameraMode.thirdPerson;
			}
		}

		if(currentCamMode == CameraMode.firstPerson)
		{
			thirdPersonCam.GetComponent<TS_ThirdPersonCamera>().enabled = false;
			SwitchCam(thirdPersonCam, firstPersonCam);
		}
		else if(currentCamMode == CameraMode.thirdPerson)
		{
			thirdPersonCam.GetComponent<TS_ThirdPersonCamera>().enabled = true;
			SwitchCam(firstPersonCam, thirdPersonCam);
		}
	}

	void SwitchCam(Camera currentCam, Camera switchToCam)
	{
		currentCam.GetComponent<Camera>().enabled = false;
		switchToCam.GetComponent<Camera>().enabled = true;
	}
}
