using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	//public GameObject spawnPoint,hands;
	public GameObject table;
	float dist;
	public GameObject inventoryGUI;
	//public Texture SoldierIcon,GunIcon,GrenadeIcon,AmmoIcon,HealthIcon;
	public GameObject gunButton,ammoButton,healthButton,grenadeButton;
	public GameObject gun, hands;
	public int grenadeCount,ammoCount,ammoCase;

	public Text playerHealthText;

	void Start () 
	{
		inventoryGUI.SetActive(false);
		//gun.SetActive(false);
		grenadeCount = 0;
		ammoCount = 0;
		ammoCase = 0;		
	}

	void Update () 
	{
		dist = Vector3.Distance(table.transform.position, transform.position);
		//print (dist);
		if(dist<3)
		{
			Cursor.visible=true;
			inventoryGUI.SetActive(true);
			transform.GetComponent<MouseLook>().enabled = false;
			Camera.main.GetComponent<MouseLook>().enabled = false;
			//spawnPoint.GetComponent<Shoot>().enabled = false;
		}
		else
		{
			Cursor.visible = false;
			inventoryGUI.SetActive(false);
			transform.GetComponent<MouseLook>().enabled = true;
			Camera.main.GetComponent<MouseLook>().enabled = true;
			//spawnPoint.GetComponent<Shoot>().enabled = true;
		}
	} 

	public void OnGunClick()
	{
		hands.GetComponent<HandAnimation>().GunActive = true;
		gun.SetActive(true);
		hands.SetActive(false);
		ammoCount=30;
	}

	public void OnAmmoClick()
	{
		ammoCase = 100;
	}

	public void OnGrenadeClick()
	{
		grenadeCount = 8;
	}

	public void OnHealthClick()
	{
		if(Player_Health.health < 100)
		{
			print ("Health Regained!");
			Player_Health.health = 100;
			//playerHealthText.GetComponent<UILabel>().text = Player_Health.health.ToString();
			playerHealthText.text = Player_Health.health.ToString();
		}
	}
}
