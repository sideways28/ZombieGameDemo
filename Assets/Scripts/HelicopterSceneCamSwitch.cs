using UnityEngine;
using System.Collections;

public class HelicopterSceneCamSwitch : MonoBehaviour {

	public Transform insideHeliCamPos;
	public Transform outHeliCamPos;

	private Transform currentTransform;

	void Start()
	{
		currentTransform = insideHeliCamPos;
	}

	void Update ()
	{
		if(Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			Debug.Log("Mouse Scrolled!");
			CameraPosChange();
		}
	}

	void CameraPosChange()
	{
		if(currentTransform == insideHeliCamPos)
		{
			currentTransform = outHeliCamPos;
			Camera.main.transform.GetComponent<MouseLook>().enabled = false;
		}
		else if(currentTransform == outHeliCamPos)
		{
			currentTransform = insideHeliCamPos;
			Camera.main.transform.GetComponent<MouseLook>().enabled = true;
		}

		Camera.main.transform.SetParent(currentTransform);
		Camera.main.transform.localPosition = Vector3.zero;	
		Camera.main.transform.localRotation = Quaternion.identity;
	}
}
