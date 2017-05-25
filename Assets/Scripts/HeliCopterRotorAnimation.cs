using UnityEngine;
using System.Collections;

public class HeliCopterRotorAnimation : MonoBehaviour {

    float delayTime = 27f;

	void Start()
	{
		StartCoroutine(LoadGameLevel());
	}

	IEnumerator LoadGameLevel () 
	{
		if(transform.position.y > 6)		
			gameObject.GetComponent<Animation>().Play();

		yield return new WaitForSeconds(delayTime);
		Application.LoadLevel("MainMenuScene");		
	}
	
}
