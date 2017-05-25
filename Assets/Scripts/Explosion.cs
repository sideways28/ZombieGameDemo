using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float explosionTime = 3;
	public GameObject explosionPrefab;
	

	void Awake()
	{
		StartCoroutine(Explode());
	}

	IEnumerator Explode () 
	{
		yield return new WaitForSeconds (explosionTime);		
		Instantiate (explosionPrefab, transform.position, transform.rotation);
		Destroy(transform.gameObject);
	}
}
