using UnityEngine;
using System.Collections;

public class MainMenuZombie : MonoBehaviour {

	GameObject Target;
	public GameObject Target1,Target2;

	void Start()
	{
		Target=Target1;
	}

	void Update () 
	{
		Vector3 lookDir = Target.transform.position - transform.position;
		lookDir.y = 0; 
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(lookDir), 30*Time.deltaTime);
		transform.position += transform.forward * 3 * Time.deltaTime;

		float DistanceFromTarget1 = Vector3.Distance(Target1.transform.position,transform.position);
		
		if(DistanceFromTarget1<1)
		{
			Target = Target2;
		}

		float DistanceFromTarget2 = Vector3.Distance(Target2.transform.position,transform.position);
		
		if(DistanceFromTarget2<1)
		{
			Target = Target1;
		}

	}
}
