using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMotor : MonoBehaviour
{
    public float gravityMultiplier = 1f;
    public float lerpTime = 10f;
    public float distanceToGround = 0.1f;

    public bool isGrounded;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 targetDirection = Vector3.zero;

    private float fallVelocity = 0f;

    private Collider myCollider;
    [HideInInspector]
    public CharacterController charController;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        myCollider = GetComponent<Collider>();
    }


    // Start is called before the first frame update
    void Start()
    {
        distanceToGround = myCollider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = OnGroundCheck();
        moveDirection = Vector3.Lerp(moveDirection,targetDirection,Time.deltaTime*lerpTime); //move from the direction to target direction in time.deltaT ime
        moveDirection.y = fallVelocity;

        charController.Move(moveDirection * Time.deltaTime);

        if(!isGrounded)
        {
            fallVelocity -= 90f * gravityMultiplier * Time.deltaTime;
        }


    }

    public bool OnGroundCheck()
    {
        RaycastHit hit;
        if(charController.isGrounded)
        {
            return true;
        }
        if(Physics.Raycast(myCollider.bounds.center,-Vector3.up,out hit,distanceToGround+0.1f)) //Ray from centre,Towards Down(-ve),info. stored in var hit,extend of Ray
        {
            return true;
        }
        return false;
    }

    public void Move(Vector3 dir)
    {
        targetDirection = dir;
    }
    public void Stop()
    {
        moveDirection = Vector3.zero;
        targetDirection = Vector3.zero;
    }
    public void Jump(float jumpSpeed)
    {
        if(isGrounded)
        {
            fallVelocity = jumpSpeed;
        }
    }
}
