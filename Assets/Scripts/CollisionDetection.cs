using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

	public bool explosion=false;
	public GameObject ExplosionPrefab;

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Bullet(Clone)")
		{
			if(!explosion)
			{
				gameObject.GetComponent<Renderer>().material.color=Color.red;
			}
			if(explosion)
			{
				Destroy(gameObject);
				Instantiate(ExplosionPrefab,transform.position,transform.rotation);
			}
		}

	}
}
