using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {
	
	public GameObject bloodPrefab, zombie;
	public Texture healthTexture;
	public static int health = 99;
	private GameObject gun;
	public AudioClip heartBeat;
	public Text healthText;
	public GameObject bloodSpat;

	void Start () 
	{
		gun = GameObject.Find("M4A3");
		Time.timeScale = 1;
		Cursor.visible=false;
		//transform.GetComponent<Inventory>().enabled = true;
	}

	void Update () 
	{
		if(health<=0)
		{
			transform.GetComponent<ExitGame>().deathButtons.SetActive(true);
			transform.GetComponent<Inventory>().enabled=false;
			Cursor.visible=true;
			health=0;
			Time.timeScale = 0;

			gun.SetActive(false);

			//transform.GetComponent<MouseLook>().enabled = false;
			//transform.GetComponent<FPSInputController>().enabled = false;

			Vector3 Temp = transform.eulerAngles;
			Temp.z = 90;
			transform.eulerAngles = Temp;
		}
	}
	
	bool soundPlayed = false;

	IEnumerator PlaySound()
	{
		if(!soundPlayed)
		{
			transform.GetComponent<AudioSource>().PlayOneShot(heartBeat);
			soundPlayed = true;
			bloodSpat.SetActive (true);

			yield return new WaitForSeconds(heartBeat.length);
			soundPlayed = false;
			bloodSpat.SetActive (false);
		}
	}

	public void HealthReduction()
	{
		//Debug.Log("Player Health Reduced");
		StartCoroutine(PlaySound());
		health-=1;
		//bloodicon = true;
		//StartCoroutine(ShowBloodOnScreen());
		//Debug.Log("Current Health : "+health);
		//healthText.GetComponent<UILabel>().text = health.ToString();
	    healthText.text = health.ToString();
	}

//	IEnumerator ShowBloodOnScreen() 
//	{
//		yield return new WaitForSeconds(5);
//		bloodIcon = false;
//	}

//	void OnGUI()
//	{
//		GUI.DrawTexture(new Rect(100, Screen.height-150, 100, 100), HealthTexture);
//		GUI.Label(new Rect(200, Screen.height-100, 300, 300),""+Health);
//
//		if(Bloodicon)
//		{
//			GUI.DrawTexture(new Rect(Screen.width/2+200, Screen.height/2+200, BloodIcon.width, BloodIcon.height), BloodIcon);
//			GUI.DrawTexture(new Rect(Screen.width/2-200, Screen.height/2-200, BloodIcon.width, BloodIcon.height), BloodIcon);
//		}
//	}
}
