using UnityEngine;
using UnityEngine.Rendering;

public class MooveMehanic : MonoBehaviour
{
    [SerializeField] private AudioPlayer audioPlayer;
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

    private bool canAttack = true;
    public Collider Swordcollider;

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
        _animator.SetBool("isEqquiped", IsSwordInHand());
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
        if (Mathf.Abs(_vertical) > 0.1f && IsGround)
        {
            audioPlayer.PlayStepSound();
        }

        _currentrotationY += _horizontal * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, _currentrotationY, 0);

        _direction = transform.forward * _vertical * _speed;
        _direction.y = m_rb.velocity.y;
        m_rb.velocity = _direction;
    }

    private void GetAnim()
    {
        _animator.SetFloat("Speed", _vertical);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsGround = true;
    }

    private void AttackPos()
    {
        bool isUIClosed = !inventoryUI.InventoryUi.activeSelf && !sellItem.panel.activeSelf;
        bool isSwordEquipped = InventoryManager.Instance.heldItem != null && InventoryManager.Instance.heldItem.name == "Sword";

        if (Input.GetButtonDown("Fire1") && IsSwordInHand()&& !inventoryUI.InventoryUi.activeSelf)
        {
            _animator.SetBool("Attack", true);
        }
    }


    public void Dead()
    {
        _animator.SetTrigger("Dead");
    }

    public bool IsSwordInHand()
    {
        return InventoryManager.Instance.heldItem != null && InventoryManager.Instance.heldItem.name == "Sword";
    }

    public void EnableCollider()
    {
        Swordcollider.enabled = true;
    }
    public void DisableCollider()
    {
        Swordcollider.enabled = false;
    }
    public void BoolEnd()
    {
        _animator.SetBool("Attack", false);
    }
}
