using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.InputSystem.Editor;
#endif


[RequireComponent(typeof(Sentient))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    //animation
    [SerializeField]
    Animator animator;

    Sentient mSentient;

    Sentient.AcceleratorVector ControlledVector;
    Sentient.ControlledVector ControlledRotation;
    Sentient.SlowlyRotateTowardVector SlowlyRotateToward;

    Sentient.Flipping FlippingCalls;

    [SerializeField]
    InputActionReference ActionReferenceMovement;
    [SerializeField]
    InputActionReference ActionReferenceBoost;
    [SerializeField]
    InputActionReference ActionReferenceAttack;
    [SerializeField]
    InputActionReference ActionReferenceAttack2;


    // run
    public int runSpeed = 1;
    public float MoveSpeed;
    float horizontal;
    float vertical;
    bool facingRight;

    bool canMove;
    bool canAttack;

    [SerializeField]
    Vector3 Movement;

    Rigidbody rb;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
        canMove = true;
        canAttack = true;
        mSentient = GetComponent<Sentient>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        ControlledRotation = new Sentient.ControlledVector();
        mSentient.AddToAllRotationalControl(ControlledRotation);
        SlowlyRotateToward = new Sentient.SlowlyRotateTowardVector(new Vector3(0, 0, 0));
        SlowlyRotateToward.Strength = 5f;
        mSentient.AddToAllRotationalControl(SlowlyRotateToward);

        ControlledVector = new Sentient.AcceleratorVector();
        ControlledVector.Strength = 10f;
        mSentient.AddToAllMovementControl(ControlledVector);
        //mSentient.AddToAllMovementControl(new Sentient.RigidbodyDifferentiation(GetComponent<Rigidbody>()));
    }

    /*
    void Update()
    {
        if (ActionReferenceAttack.action.WasPressedThisFrame())
        {
            //animator.SetTrigger("Attack1");
        }

        if (ActionReferenceAttack2.action.WasPressedThisFrame())
        {
            //animator.SetTrigger("Attack2");
        }
    }

    */

    public void SetCanMoveFalse()
    {
        canMove = false;
    }

    public void SetCanMoveTrue()
    {
        canMove = true;
    }
    public void SetCanAttackFalse()
    {
        canAttack = false;
    }

    public void SetCanAttackTrue()
    {
        canAttack = true;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Vector3 _Movement = ActionReferenceMovement.action.ReadValue<Vector2>();

            if (!(_Movement.x == 0) || !(_Movement.y == 0))
            {
                animator.SetBool("Moving", true);
            }
            else animator.SetBool("Moving", false);

            //if (_Movement.x > 0) { ControlledRotation.ChangeVector(new Vector3(0, 0, 0)); }
            //else if (_Movement.x < 0) { ControlledRotation.ChangeVector(new Vector3(0, 180, 0)); }

            float Boost = 1;

            if (ActionReferenceBoost.action.inProgress) Boost = 2f;
            else Boost = 1f;

            Movement = Camera.main.transform.TransformDirection(new Vector3(_Movement.x, 0, _Movement.y)); //Set movement to be relative to camera

            //Movement = new Vector3(Movement.x, 0, Movement.z).normalized;

            ControlledVector.TargetVelocity = Movement * Boost * 5;

            transform.eulerAngles = mSentient.GetAllRotationalControlVector3();
            Vector3 _FullMove = mSentient.GetAllMovementControlVector3();

            SlowlyRotateToward.Direction = Movement;


            rb.velocity = new Vector3(_FullMove.x, _FullMove.y, _FullMove.z);
            //Flip(horizontal);
        }
    }
}
