using UnityEngine;
using System.Collections;

public class RotateAboutObject : MonoBehaviour {

	public GameObject pivot;
	public float RotateSpeed=50;
	//Vector3 Origin;

	void Start()
	{
		//Origin = transform.position;
	}

	void Update () 
	{
		if (transform.position.y > 0) 
		{
			transform.RotateAround (pivot.transform.position, Vector3.up, 180 * RotateSpeed * Time.deltaTime);
		}
		RotateSpeed = transform.position.y;
	}
}
