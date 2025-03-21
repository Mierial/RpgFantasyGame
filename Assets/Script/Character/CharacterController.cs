using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string JUMP = "Jump";
    private const string ATTACK = "Fire1";
    private const string ROLL = "Fire2";
    private const string BLOCK = "Fire3";

    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float animationSmoothTime = 0.1f;

    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded;
    private float currentSpeed;
    private float velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        HandleAnimations();
    }

    private void Update()
    {
        HandleJump();
        HandleAttack();
        HandleRoll();
        HandleBlock();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis(HORIZONTAL);
        float vertical = Input.GetAxis(VERTICAL);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float speed = isRunning ? runSpeed : walkSpeed;
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, targetAngle, 0), Time.deltaTime * rotationSpeed);
            rb.velocity = direction * speed + new Vector3(0, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    private void HandleAnimations()
    {
        float horizontal = Input.GetAxis(HORIZONTAL);
        float vertical = Input.GetAxis(VERTICAL);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        animator.SetBool("RunForward", isRunning && vertical > 0);
        animator.SetBool("RunBackward", isRunning && vertical < 0);
        animator.SetBool("RunLeft", isRunning && horizontal < 0);
        animator.SetBool("RunRight", isRunning && horizontal > 0);
        animator.SetBool("WalkForward", !isRunning && vertical > 0);
        animator.SetBool("WalkBackward", !isRunning && vertical < 0);
        animator.SetBool("StrafeLeft", !isRunning && horizontal < 0);
        animator.SetBool("StrafeRight", !isRunning && horizontal > 0);
        animator.SetBool("RunBackwardLeft", isRunning && vertical < 0 && horizontal < 0);
        animator.SetBool("RunBackwardRight", isRunning && vertical < 0 && horizontal > 0);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown(JUMP) && isGrounded)
        {
            animator.SetTrigger("JumpWhileRunning");
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false;
        }
    }

    private void HandleAttack()
    {
        if (Input.GetButtonDown(ATTACK))
        {
            animator.SetTrigger("MeleeAttack_OneHanded");
        }
    }

    private void HandleRoll()
    {
        if (Input.GetButtonDown(ROLL))
        {
            animator.SetTrigger("RollForward");
        }
    }

    private void HandleBlock()
    {
        bool isBlocking = Input.GetButton(BLOCK);
        animator.SetBool("BlockingLoop", isBlocking);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}