using UnityEngine;
using System.Collections;

public class HandAnimation : MonoBehaviour {

	public GameObject axe,Gun;
	public bool GunActive = false;
	float Range=1.0f;
	public AudioClip AxeSound;

	void Start()
	{
		Cursor.visible=false;
	}

	void Update () 
	{
		RaycastHit Hit;

		if(transform.gameObject.activeSelf)
		{
			if(Input.GetAxis("Mouse ScrollWheel")>0&&GunActive)
			{
				Gun.SetActive(true);
				transform.gameObject.SetActive(false);
			}

			if(!GetComponent<Animation>().IsPlaying("AxeAnimation")&&Input.GetAxis("Vertical")>0)
			{
				GetComponent<Animation>().Play ("RunningAnimation");
			}

			if(Input.GetButtonDown("Fire1"))
			{
				GetComponent<Animation>().Play("AxeAnimation");
				GetComponent<AudioSource>().PlayOneShot(AxeSound);
			}

			Debug.DrawRay(axe.transform.position, -axe.transform.up * Range, Color.blue);

			if(Physics.Raycast(axe.transform.position, -axe.transform.up,out Hit, Range) && GetComponent<Animation>().IsPlaying("AxeAnimation"))
			{
				if(Hit.transform.name == "Zombie")
				{
					Hit.collider.GetComponent<ZombieScript>().ZombieHealth -=20;
				}
			}

		}
	}
}
