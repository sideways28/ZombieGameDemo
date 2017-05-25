using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour
{
    [System.NonSerialized]
    public float lookWeight;

    [System.NonSerialized]
    private Transform enemy;

    public float animSpeed = 1.5f;
    public float lookSmoother = 3f;
    public bool useCurves;

    private Animator anim;
    private AnimatorStateInfo currentBaseState;
    private CapsuleCollider col;

    private static int idleState = Animator.StringToHash("Base Layer.Idle");
    private static int WalkState = Animator.StringToHash("Base Layer.Walk");
    private static int RunState = Animator.StringToHash("Base Layer.Run");
    private static int RunningJumpState = Animator.StringToHash("Base Layer.RunningJump");
    private static int DanceState = Animator.StringToHash("Base Layer.GangnamStyle_dance");

    public Transform rightHandIkTarget;
    private float ikWeight = 0.5f;

    private bool aim = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();
        //enemy = GameObject.Find("PlayerEnemy").transform;	
    }

    void OnAnimatorIK()
    {
        if (aim)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, ikWeight);
            anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandIkTarget.position);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            //anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandIkTarget.position);
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftShift))
        {
            aim = true;
        }
        else
        {
            aim = false;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);
        anim.speed = animSpeed;
        anim.SetLookAtWeight(lookWeight);
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);


        //Enable camera Orbiting if player is idle

        if (v == 0 && h == 0)
        {
            TS_ThirdPersonCamera.camOrbit = true;
        }
        else
        {
            TS_ThirdPersonCamera.camOrbit = false;
        }

        // Run
        if (currentBaseState.fullPathHash == WalkState)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Run", true);
            }
        }
        if (currentBaseState.fullPathHash == RunState)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Run", false);
            }
        }

        // Stare

        //			if(Input.GetButton("Fire2"))
        //			{
        //anim.SetLookAtPosition(enemy.position);
        lookWeight = Mathf.Lerp(lookWeight, 1f, Time.deltaTime * lookSmoother);
        //			}

        //			else
        //			{
        //				lookWeight = Mathf.Lerp(lookWeight,0f,Time.deltaTime*lookSmoother);
        //			}

        // Running Jump

        if (currentBaseState.fullPathHash == RunState)
        {
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetBool("RunningJump", true);
            }
        }

        else if (currentBaseState.fullPathHash == RunningJumpState)
        {

            if (!anim.IsInTransition(0))
            {
                if (useCurves)
                    col.height = anim.GetFloat("ColliderHeight");

                anim.SetBool("RunningJump", false);
            }

            Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.distance > 1.75f)
                {
                    anim.MatchTarget(hitInfo.point, Quaternion.identity, AvatarTarget.Root, new MatchTargetWeightMask(new Vector3(0, 1, 0), 0), 0.35f, 0.5f);
                }
            }
        }


        // Dance*****
        else if (currentBaseState.fullPathHash == idleState)
        {
            if (Input.GetKey(KeyCode.I))
            {
                anim.SetBool("Dance", true);
            }
            else if (!anim.IsInTransition(0))
            {
                anim.SetBool("Dance", false);
            }
        }

        if (currentBaseState.fullPathHash == DanceState)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("EndDance", true);
            }
            else if (!anim.IsInTransition(0))
            {
                anim.SetBool("EndDance", false);
            }
        }

        // Idle LeftPunch*****

        if (currentBaseState.fullPathHash == idleState)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                anim.SetBool("LeftPunch", true);
            }
            else if (!anim.IsInTransition(0))
            {
                anim.SetBool("LeftPunch", false);
            }
        }

        // Idle RightPunch*****

        if (currentBaseState.fullPathHash == idleState)
        {
            if (Input.GetKey(KeyCode.E))
            {
                anim.SetBool("RightPunch", true);
            }
            else if (!anim.IsInTransition(0))
            {
                anim.SetBool("RightPunch", false);
            }
        }

        // Walking LeftPunch

        if (currentBaseState.fullPathHash == WalkState)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                anim.SetBool("LeftPunch", true);
            }
            else if (!anim.IsInTransition(0))
            {
                anim.SetBool("LeftPunch", false);
            }
        }

        // Walking RightPunch

        if (currentBaseState.fullPathHash == WalkState)
        {
            if (Input.GetKey(KeyCode.E))
            {
                anim.SetBool("RightPunch", true);
            }
            else if (!anim.IsInTransition(0))
            {
                anim.SetBool("RightPunch", false);
            }
        }

        //Jump

        if (currentBaseState.fullPathHash == idleState)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("Jump", true);
            }
            else if (!anim.IsInTransition(0))
            {
                anim.SetBool("Jump", false);
            }
        }
    }
}