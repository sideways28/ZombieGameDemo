using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float WalkSpeed=15;
	float RunSpeed;
	float OriginalWalkSpeed;
	Vector3 Forward,Right;

	public bool grounded = false;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;

	void Start()
	{
		Forward = transform.forward;
		Right = transform.right;
		OriginalWalkSpeed=WalkSpeed;
		RunSpeed = 2*WalkSpeed;
	}

	void Update() 
	{
		Cursor.visible=false;

		moveDirection.y -= gravity * Time.deltaTime;
		CharacterController controller = (CharacterController)GetComponent(typeof(CharacterController));
		CollisionFlags flags = controller.Move(moveDirection * Time.deltaTime);
		grounded = (flags & CollisionFlags.CollidedBelow) != 0;

			if(Input.GetAxis("Vertical")>0)
			{
				transform.Translate(Forward*0.01f*WalkSpeed);
				if(Input.GetKeyDown(KeyCode.LeftShift))
				{
					WalkSpeed=RunSpeed;
				}
				else if(Input.GetKeyUp(KeyCode.LeftShift))
				{
					WalkSpeed=OriginalWalkSpeed;
				}
			}
			if(Input.GetAxis("Vertical")<0)
			{
				transform.Translate(-Forward*0.01f*WalkSpeed);
			}
			if(Input.GetAxis("Horizontal")>0)
			{
				transform.Translate(Right*0.01f*WalkSpeed);
			}
			if(Input.GetAxis("Horizontal")<0)
			{
				transform.Translate(-Right*0.01f*WalkSpeed);
			}
		if(grounded)
		{
			if (Input.GetButton ("Jump"))
				moveDirection.y = 8.0f;
			if(Input.GetKeyDown(KeyCode.C))
			{
			moveDirection.y = gravity+10 * Time.deltaTime;
			}
			else
			moveDirection.y -= gravity * Time.deltaTime;
		}
	}
	
}
	