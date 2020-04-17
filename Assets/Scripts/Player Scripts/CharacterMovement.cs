using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private MovementMotor motor;
    private Vector3 direction;
    private Animator anim;
    private Camera mainCamera;

    private float speed_Move_Multiplier = 1f;

    private string PARAMETER_STATE = "State";
    private string PARAMETER_ATTACK_TYPE = "AttackType";
    private string PARAMETER_ATTACK_INDEX = "AttackIndex";

    public AttackAnimation[] attack_Animations;
    public string[] combo_AttackList;
    public int combo_Type;

    private int attack_Index = 0;
    private string[] combo_List;
    private int attack_Stack;
    private float attack_Stack_TimeTemp;

    private bool isAttacking;

    private GameObject atkPoint;
    public GameObject fireTornado;

    public float move_Magnitude = 0.05f;
    public float speed = 0.7f;
    public float speed_Move_WhileAttack = 0.1f;
    public float speed_Attack = 1.5f;
    public float turnSpeed = 10f;
    public float speed_Jump = 20f;

    private void Awake()
    {
        motor = GetComponent<MovementMotor>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        anim.applyRootMotion = false;
        mainCamera = Camera.main;
        atkPoint = GameObject.Find("Player Attack Point");
        atkPoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MovementAndJumping();
        HandleAttackAnimations();
        if(MouseLock.MouseLocked)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Attack();
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Attack();
                StartCoroutine(SpecialAttack());
            }
        }

    }

    private Vector3 MoveDirection
    {
        get { return direction; }
        set
        {
            direction = value * speed_Move_Multiplier;
            if (direction.magnitude > 0.1f)
            {
                var newRotation = Quaternion.LookRotation(direction); //rotate the player to see in this direction
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * turnSpeed);
            }
            direction *= speed * (Vector3.Dot(transform.forward, direction) + 3f) * 4f; // Dot - product of two vector magnitudes , 1 for testing movement , *5 also testing values 
            motor.Move(direction);

            AnimationMove(motor.charController.velocity.magnitude * 0.05f);
        }
    }
    void Moving(Vector3 dir, float mult)
    {

        if(isAttacking)
        {
            speed_Move_Multiplier = speed_Move_WhileAttack * mult;
        }
        else
        {
            speed_Move_Multiplier = 1*mult;
        }

        MoveDirection = dir;
    }
    void Jump()
    {
        motor.Jump(speed_Jump); 
    }
    void  AnimationMove(float magnitude)
    {
        if(magnitude > move_Magnitude)
        {
            float speed_Animation = magnitude * 2f;
            if(speed_Animation<1f)
            {
                speed_Animation = 1f;
            }
            if(anim.GetInteger(PARAMETER_STATE)!=2)
            {
                anim.SetInteger(PARAMETER_STATE, 1);
                anim.speed = speed_Animation;
            }
        }
        else
        {
            if (anim.GetInteger(PARAMETER_STATE) != 2)
            {
                anim.SetInteger(PARAMETER_STATE, 0); 
            }

        }
    }
    void MovementAndJumping()
    {
        Vector3 moveInput = Vector3.zero;
        Vector3 forward = Quaternion.AngleAxis(-90, Vector3.up) * mainCamera.transform.right;
        moveInput += forward * Input.GetAxis("Vertical");
        moveInput += mainCamera.transform.right * Input.GetAxis("Horizontal");
        moveInput.Normalize(); // make vector mag 1
        Moving(moveInput.normalized,1f); //keeps same dir but mag 1
        if(Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }
    void ResetCombo()
    {
        attack_Index = 0;
        attack_Stack = 0;
        isAttacking = false;
    }

    void FightAnimation()
    {
        if(combo_List !=null && attack_Index >= combo_List.Length)
        {
            ResetCombo();
        }

        if(combo_List !=null && combo_List.Length >0)
        {
            int motionIndex = int.Parse(combo_List[attack_Index]); //convert a string to integer since combo list is string list
            if(motionIndex < attack_Animations.Length) 
            {
                anim.SetInteger(PARAMETER_STATE, 2);
                anim.SetInteger(PARAMETER_ATTACK_TYPE, combo_Type);
                anim.SetInteger(PARAMETER_ATTACK_INDEX, attack_Index);
            }
        }
    }

    void HandleAttackAnimations()
    {
        if(Time.time > attack_Stack_TimeTemp +0.5f)
        {
            attack_Stack = 0; // reset
        }
        combo_List = combo_AttackList[combo_Type].Split(","[0]); // will return splitted array by removing delimeter by taking , as a parameter
        int state = anim.GetInteger(PARAMETER_STATE);
        if (state == 2)
        {
            anim.speed = speed_Attack;
            AnimatorStateInfo stateInfo =anim.GetCurrentAnimatorStateInfo(0); // getting base layer information
            if (stateInfo.IsTag("Attack"))
            {
                //means in attack anim
                int motionIndex = int.Parse(combo_List[attack_Index]);

                if (stateInfo.normalizedTime > 0.9f) // normalisetime of the state and greater than 0.9 means anim coming to end
                {
                    anim.SetInteger(PARAMETER_STATE, 0);
                    isAttacking = false;
                    attack_Index++;

                    if(attack_Stack >1)
                    {
                        FightAnimation();
                    }
                    else
                    {
                        if(attack_Index >=combo_List.Length)
                        {
                            ResetCombo();
                        }
                    }
                }

            }
        } 

    }

    void Attack()
    {
        if(attack_Stack <1 || (Time.time > attack_Stack_TimeTemp + 0.2f && Time.time < attack_Stack_TimeTemp +1f))
        {
            attack_Stack++;
            attack_Stack_TimeTemp = Time.time;
        }

        FightAnimation();
    }
    void Attack_Began()
    {
        atkPoint.SetActive(true);
    }
    void Attack_End()
    {
        atkPoint.SetActive(false);
    }
    IEnumerator SpecialAttack()
    {
        yield return new WaitForSeconds(0.4f);
        Instantiate(fireTornado, transform.position + transform.forward * 2.5f, Quaternion.identity);
    }

} // class
