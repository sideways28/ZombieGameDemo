using UnityEngine;
using System.Collections;

public class ZombieScript : MonoBehaviour {

	public GameObject Player;
	public float ZombieHealth = 100;
	public bool ZombieDead = false;
    public float deadSeconds=0.0f;

	private float Speed = 2;
	private GameObject detonate;
	private float distOfExplosion;

	void Start()
	{

	}

	void ZombieGrenadeDamage()
	{
		if(detonate)
		{
			distOfExplosion = Vector3.Distance(transform.position,detonate.transform.position);
			ZombieHealth-=1/distOfExplosion;
		}
	}

    void Follow()
    {
        Vector3 lookDir = Player.transform.position - transform.position;
        lookDir.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDir), 30 * Time.deltaTime);
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

	void Update () 
	{
		detonate = GameObject.Find("Detonator-Heatwave(Pro)(Clone)");

		ZombieGrenadeDamage();

		Animator animator = GetComponent<Animator>(); 

		float DistanceFromPlayer = Vector3.Distance(transform.position,Player.transform.position);

		if(DistanceFromPlayer<50)
		{
			animator.SetBool("Walk",true);
		}

		if(ZombieHealth<80)
		{
			Speed=3;
			animator.SetBool("Run",true);
		}
		if(ZombieHealth<50)
		{
			Speed=2;
			animator.SetBool("Injured",true);
		}
        if (ZombieHealth > 5)
        {
            Follow();
        }
		else
		{
			transform.eulerAngles = new Vector3(72.15572f,329.55f,52.29149f);
			animator.SetBool("Dead",true);
			ZombieDead=true;
            deadSeconds += Time.deltaTime;
		}

        if (deadSeconds > 2)
		{
			gameObject.SetActive(false);
		}

		if(!ZombieDead && Vector3.Distance(transform.position,Player.transform.position)<2)
		{
			Player.GetComponent<Player_Health>().HealthReduction();
		}

	}

}
