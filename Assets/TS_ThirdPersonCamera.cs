using UnityEngine;
using System.Collections;

public class TS_ThirdPersonCamera : MonoBehaviour {

	public Transform target;
	public float height = 5f;
	public float distance = 5f;
	public float lerpRate = 10f;

	public static bool camOrbit = false;
	private float camOrbitAngle = 0f;
	public float camOrbitSpeed = 2.0f;
	
	void Start ()
	{
		if(target == null)
		{
			target = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}
	
	void LateUpdate ()
	{
		if(target)
		{
			if(camOrbit)
			{
				transform.RotateAround(target.position, Vector3.up, camOrbitAngle);

				if(Input.GetAxis("Mouse X") > 0f)
				{
					camOrbitAngle+=Input.GetAxis("Mouse X") * camOrbitSpeed * Time.deltaTime;
				}
				else if(Input.GetAxis("Mouse X") < 0f)
				{
					camOrbitAngle+=Input.GetAxis("Mouse X") * camOrbitSpeed * Time.deltaTime;
				}
				else
				{
					camOrbitAngle = 0;
				}
			}
			else 
			{
				//Set the camera position behind the target
				transform.position = Vector3.Lerp(transform.position,
			    	                              target.position + target.up * height - target.forward * distance,
			        	                          lerpRate * Time.deltaTime);
			}

			//Look At target
			transform.LookAt(target);
		}
	}
}
