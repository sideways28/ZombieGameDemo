using UnityEngine;
using System.Collections;

public class BulletMark2 : MonoBehaviour {
	
	public GameObject BulletMark;
	private GameObject BulletClone;

	void Start()
	{
		BulletClone=GameObject.Find("Bullet(Clone)");
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.GetComponent<Collider>())
		{
			//print ("BulletHitTheWall");
			ContactPoint contact = col.contacts[0];

			Vector3 pos = contact.point;
			Instantiate(BulletMark, new Vector3 (pos.x,pos.y,pos.z), Quaternion.identity);
			Destroy(BulletClone);
		}

	}
}

