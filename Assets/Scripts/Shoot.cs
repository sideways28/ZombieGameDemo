using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public Rigidbody BulletPrefab,GrenadePrefab;
	public GameObject LeftHandPivot,GrenadeSpawnPoint;
	public float speed = 100;
	public AudioClip ShootSound;
	public Camera ADS;
	//GameObject Crosshair;
	int AmmoCount,AmmoCase,GrenadeCount;
	private GameObject Gun;
	int ReloadBulletNumber;

	void Start()
	{
		//Crosshair=GameObject.Find ("Crosshair");
		ADS.enabled=false;
		Gun=GameObject.Find("M4A3");
	}

	void Update () 
	{
		AmmoCount = GameObject.Find("First Person Controller").GetComponent<Inventory>().ammoCount;
		AmmoCase = GameObject.Find("First Person Controller").GetComponent<Inventory>().ammoCase;
		GrenadeCount = GameObject.Find("First Person Controller").GetComponent<Inventory>().grenadeCount;
		//print (AmmoCount);
		if(Input.GetButtonDown("Fire1") && AmmoCount>0)
		{
			shoot();
			GameObject.Find("First Person Controller").GetComponent<Inventory>().ammoCount-=1;

			ReloadBulletNumber +=1; 
			//print(ReloadBulletNumber);

			//InvokeRepeating("shoot",0.0f,1.0f);
		}


		if(Input.GetKeyDown(KeyCode.R) && AmmoCase>0)
		{
			if(AmmoCount<30)
			{
			GameObject.Find("First Person Controller").GetComponent<Inventory>().ammoCase-=ReloadBulletNumber;
			GameObject.Find("First Person Controller").GetComponent<Inventory>().ammoCount=30;
			ReloadBulletNumber = 0; 
			}
			if(AmmoCase<30)
			{
				GameObject.Find("First Person Controller").GetComponent<Inventory>().ammoCase = 0;
				GameObject.Find("First Person Controller").GetComponent<Inventory>().ammoCount = AmmoCase;
			}
		}
		
		if(Input.GetButtonDown("Fire2"))
		{
			ADS.enabled=true;
			//Crosshair.guiTexture.enabled=false;
		}
		
		if(Input.GetButtonUp("Fire2"))
		{
			ADS.enabled=false;
			//Crosshair.guiTexture.enabled=true;
		}
		if(Input.GetButtonDown("Fire3") && GrenadeCount>0)
		{
			GameObject.Find("First Person Controller").GetComponent<Inventory>().grenadeCount-=1;

			LeftHandPivot.GetComponent<Animation>().Play();

			//if(Time.time > (creationTime+0.1f))
			{
				Rigidbody Grenade = Instantiate(GrenadePrefab,GrenadeSpawnPoint.transform.position,GrenadeSpawnPoint.transform.rotation) as Rigidbody;
				Grenade.velocity = transform.TransformDirection(Vector3.forward*20);
			}

		}
	}

	void shoot()
	{
		Gun.GetComponent<Animation>().Play("Recoil");
		Rigidbody newbullet=Instantiate(BulletPrefab,transform.position,transform.rotation) as Rigidbody;
		newbullet.velocity = transform.TransformDirection(Vector3.forward*speed);
		GetComponent<AudioSource>().PlayOneShot(ShootSound);
	}
}
