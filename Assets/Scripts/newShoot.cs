using UnityEngine;
using System.Collections;

public class newShoot : MonoBehaviour {

	public GameObject blood,bulletmark,muzzleFlash,Gun,Hands;
	//public float Damage=100;
	public Texture Crosshair;
	//private GameObject Zombie;
	public GameObject HandForGrenade;
	private Ray ray = new Ray();
	private RaycastHit hit = new RaycastHit();
	public int Damage;
	public GameObject inventory;

	void Start()
	{
		Cursor.visible=false;
	}

	void Update () 
	{
		ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f,Screen.height*0.5f,0));

		if(Input.GetAxis("Mouse ScrollWheel")<0)
		{
			Gun.SetActive(false);
			Hands.SetActive(true);
		}

//		if(Input.GetButtonDown("Fire3"))
//		{
//			HandForGrenade.transform.GetComponent<Animation>().Play("GrenadeThrow");
//		}

		if(/*!GrenadeThrowAnimation.anim.IsInTransition(0) &&*/ Input.GetButtonDown("Fire1") && !inventory.activeSelf)
		{
			GetComponent<AudioSource>().Play();
			Gun.transform.GetComponent<Animation>().Play("Recoil");
			muzzleFlash.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);

			//GameObject BulletSparks=Instantiate(BulletSpark,transform.position,transform.rotation)as GameObject;
			//Destroy(BulletSparks,0.2f);

			if(Physics.Raycast(ray,out hit,1000))
			{
				if(hit.transform.gameObject.name=="Zombie")
				{
					hit.transform.gameObject.GetComponent<ZombieScript>().ZombieHealth-=5;
					GameObject bloodmark = Instantiate(blood,hit.point,Quaternion.LookRotation(hit.normal))as GameObject;
					Destroy(bloodmark,0.5f);
				}
				else if(hit.transform.gameObject.name=="Car_Sedan")
				{
					hit.transform.gameObject.GetComponent<Car_Blast>().BulletHit+=1;
				}
				else
				{
					GameObject particle2 = Instantiate(bulletmark, hit.point, Quaternion.LookRotation(hit.normal))as GameObject;
					Destroy(particle2,10.0f);
				}
			}
		}
		else
		{
			muzzleFlash.transform.localScale = new Vector3(0.001f, 0.001f, 1.0f);
		}
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(Screen.width*0.5f,Screen.height*0.5f,50,50),Crosshair);
	}
	
}
