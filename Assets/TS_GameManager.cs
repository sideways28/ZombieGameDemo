using UnityEngine;
using System.Collections;

public class TS_GameManager : MonoBehaviour {

	static TS_GameManager _instance;

	public static TS_GameManager managerInstance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindGameObjectWithTag("ManagerObject").GetComponent<TS_GameManager>();
			}

			return _instance;
		}
	}

	public bool isPaused = false;
	public float timeScale = 1f;
}
