using UnityEngine;
using System.Collections;

public class Commado : MonoBehaviour {

	public GameObject target;
	Animator anim;

	void Start () 
	{
		anim=gameObject.GetComponent<Animator>();
	}
	

	void Update () 
	{
		float PositionX = target.transform.position.x;
		float PositionY = target.transform.position.y;
		float PositionZ = target.transform.position.z;

		float dist=Vector3.Distance(transform.position,target.transform.position);

		if(dist>5)
		{
			transform.LookAt(new Vector3 (PositionX,PositionY,PositionZ));
		}

		if(dist>3)
		{
			anim.SetBool("Walk",true);
		}
		else
		{
			anim.SetBool("Walk",false);
		}
		if(dist>10)
		{
			anim.SetBool("Run",true);
		}
		else
		{
			anim.SetBool("Run",false);
		}
	}
}
