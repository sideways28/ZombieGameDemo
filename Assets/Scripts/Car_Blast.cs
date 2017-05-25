using UnityEngine;
using System.Collections;

public class Car_Blast : MonoBehaviour {


	public GameObject Car_Idle,Car_Wracked,Fire1,Player;
	public GameObject ExplosionPrefab;
	public int BulletHit=0;

	void Start()
	{
		Fire1.SetActive(false);
		Car_Wracked.SetActive(false);
	}
	
	void Update()
	{
		if(BulletHit==3&&Fire1)
		{
			if(Vector3.Distance(Fire1.transform.position,Player.transform.position)<5)
			{
				Player.GetComponent<Player_Health>().HealthReduction();
			}
			if(Vector3.Distance(Fire1.transform.position,Player.transform.position)<20)
			{
			print ("Players Distance from Car = " + Vector3.Distance(Fire1.transform.position,Player.transform.position));
			}

		}

		if(BulletHit==3)
		{
			Fire1.SetActive(true);
		}

		if(BulletHit==10)
		{
			Car_Wracked.GetComponent<Animation>().Play("CarBlastAnimation");
		}

		if(BulletHit==10 && Car_Wracked.GetComponent<Animation>().IsPlaying("CarBlastAnimation"))
		{
			Instantiate(ExplosionPrefab,transform.position,transform.rotation);
			BulletHit=11;
		}

		if(BulletHit>10)
		{
			Car_Idle.SetActive(false);
			Car_Wracked.SetActive(true);
		}
	}



}
