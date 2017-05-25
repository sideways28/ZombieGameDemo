using UnityEngine;
using System.Collections;

public class DestroyGameobject : MonoBehaviour {



	void Update () 
	{
		Destroy(gameObject,0.1f);
	}
}
