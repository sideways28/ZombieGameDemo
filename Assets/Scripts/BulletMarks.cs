using UnityEngine;
using System.Collections;

public class BulletMarks : MonoBehaviour {

	public GameObject BulletMark;

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Bullet(Clone)")
		{
			print ("BulletHitTheWall");
			ContactPoint contact = col.contacts[0];
			//Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			Instantiate(BulletMark, new Vector3 (pos.x,pos.y,transform.position.z+transform.localScale.z/2), Quaternion.identity);
			Instantiate(BulletMark, new Vector3 (pos.x,pos.y,transform.position.z-transform.localScale.z/2), Quaternion.identity);
		}
	}
}
