using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class MooveMeh : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Jump = "Jump";
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;
    [SerializeField] private float rotationSpeed;

    public InventoryUI inventoryUI;
    public BothItem sellItem;
    public EatFood eatfooding;

    private Animator _animator;
    private Rigidbody m_rb;
    private float _currentrotationY;
    private float _horizontal;
    private float _vertical;
    private Vector3 _direction;
    private bool IsGround;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsGround", IsGround);
        IsGround = true;

    }
    private void FixedUpdate()
    {
         
        _horizontal = Input.GetAxis(Horizontal);
        _vertical = Input.GetAxis(Vertical);


        moovePlayer();
        GetAnim();
        GetJump();
        AttackPos();
        _animator.SetBool("isEqquiped", isSwordInHand());

    }
    public void GetJump()
    {
        if (Input.GetButtonDown("Jump") && IsGround)
        {
            _animator.SetTrigger(Jump);
            m_rb.velocity = new Vector3(m_rb.velocity.x, _jumpForse, m_rb.velocity.z);
            IsGround = false;
        }
    }


    private void moovePlayer()
    {

        _currentrotationY += _horizontal * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, _currentrotationY, 0);

        _direction = transform.forward * _vertical * _speed;
        _direction.y = m_rb.velocity.y;
        m_rb.velocity = _direction;



    }
    private void GetAnim()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_vertical));
    }
    private void OnCollisionEnter(Collision collision)
    {
        IsGround = true;
    }
    private void AttackPos() 
    {
        bool isAttacking = Input.GetButton("Fire1") && !inventoryUI.InventoryUi.activeSelf && !sellItem.panel.activeSelf;
        _animator.SetBool("Attack", isAttacking);

    }

    public void Dead()
    {
        _animator.SetTrigger("Dead");
    }
    private bool isSwordInHand()
    {
        return InventoryManager.Instance.heldItem != null && InventoryManager.Instance.heldItem.name == "Sword";
    }

}