using UnityEngine;
using System.Collections;

public class GrenadeThrowAnimation : MonoBehaviour {

	public static Animation animation;
	public Rigidbody grenadePrefab;
	public GameObject grenadeSpawnPoint;

	void Start()
	{
		animation = transform.GetComponent<Animation>();
	}

	IEnumerator Play()
	{
		animation.Play("GrenadeThrow");
		yield return new WaitForSeconds(0.3f);

		Rigidbody grenade = Instantiate(grenadePrefab, grenadeSpawnPoint.transform.position, grenadeSpawnPoint.transform.rotation) as Rigidbody;
		grenade.name = "Grenade";
		grenade.velocity = transform.TransformDirection(Vector3.forward*20);
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(2))
		{
			StartCoroutine(Play());
		}
	}
}
