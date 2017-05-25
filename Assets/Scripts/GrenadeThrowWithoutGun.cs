using UnityEngine;
using System.Collections;

public class GrenadeThrowWithoutGun : MonoBehaviour {

	public Rigidbody grenadePrefab;

	void Update()
	{
		if(Input.GetMouseButtonDown(2))// && !GrenadeThrowAnimation.anim.IsInTransition(0))
		{
			Rigidbody grenade = Instantiate(grenadePrefab,transform.position,transform.rotation) as Rigidbody;
			grenade.name = "Grenade";
			grenade.velocity = transform.TransformDirection(Vector3.forward*20);
		}
	}
}
