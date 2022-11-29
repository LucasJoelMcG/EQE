using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _moveDirection = Vector2.zero; //Atajo de (X:0;Y:0)
    private PlayerInputsAction playerControls;
    private PlayerAnimation _anim;
    private AudioSource _audioSword;
    private GameObject _attackArea = default;
    private GameObject _attack1 = default;
    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private CapsuleCollider2D _capsuleCollider;
    public Vector2 readMoveDirection;
    

    [SerializeField] private GameObject rangedSlash;
    [SerializeField] private Transform shotPoint;
    private bool canRangedAttack = true;
    // private bool isRangedAttacking;
    [SerializeField] private float rangedAttackCooldown = 5f;

    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashinPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
        playerControls = new PlayerInputsAction();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _anim = GetComponent<PlayerAnimation>();
        _attackArea = transform.GetChild(0).gameObject;
        _attack1 = transform.GetChild(1).gameObject;
        _audioSword = GetComponentInChildren<AudioSource>();
    }

    private void OnEnable()
    {
        playerControls.Player.Move.Enable();
        playerControls.Player.Attack.Enable();
        playerControls.Player.RangedAttack.Enable();
        playerControls.Player.Dash.Enable();
        //Cuando el jugador aprete la tecla de Attack se ejecuta el evento Attack() de esta clase.
        playerControls.Player.Attack.performed += Attack;
        playerControls.Player.Dash.performed += Dash;
        playerControls.Player.RangedAttack.performed += RangedAttack;
    }

    private void OnDisable()
    {
        playerControls.Player.Move.Disable();
        playerControls.Player.Attack.Disable();
        playerControls.Player.RangedAttack.Disable();
        playerControls.Player.Dash.Disable();

    }

    private void Move()
    {
     
        if (_moveDirection.x != 0f )
        {
            Flip();
        }
    }

    private void Flip()
    {
        if ( _moveDirection.x < 0f)
        {
            _spriteRenderer.flipX = false;
           rangedSlash.transform.localScale = new Vector2(1f, 1f);
            shotPoint.transform.localScale = new Vector2(1f, 1f);
            _attackArea.transform.localScale = new Vector2(-1f, 1f);
            _attack1.transform.localScale = new Vector2(-0.8f, 0.8f);
            _attack1.transform.localPosition = new Vector2(-0.5f, 0f);
        }
        if (_moveDirection.x > 0f)
        {
            _spriteRenderer.flipX = true;
           rangedSlash.transform.localScale = new Vector2(-1f, 1f);
            shotPoint.transform.localScale = new Vector2(-1f, 1f);
           _attackArea.transform.localScale = new Vector2(1f, 1f);
            _attack1.transform.localScale = new Vector2(0.8f, 0.8f);
            _attack1.transform.localPosition = new Vector2(0.5f, 0f);
        }

    }

    private void Attack(InputAction.CallbackContext context)
    {
        _anim.Attack();
        attacking = true;
        _attackArea.SetActive(attacking);
        _attack1.SetActive(attacking);
        _audioSword.Play();
        return;
    }

    private void RangedAttack(InputAction.CallbackContext context)
    {
        if (context.performed && canRangedAttack)
        {
            StartCoroutine(RangedAttack());
        }
    }

    private IEnumerator RangedAttack()
    {
        _anim.Attack();
        Instantiate(rangedSlash, shotPoint.position, rangedSlash.transform.rotation);
        canRangedAttack = false;
        //isRangedAttacking = true;
        yield return new WaitForSeconds(rangedAttackCooldown);
        //isRangedAttacking = false;
        canRangedAttack = true;
    }
    private void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        _rb.velocity = new Vector2(_moveDirection.x * dashinPower,0f);
        _capsuleCollider.enabled = false;
        _trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        _trailRenderer.emitting = false;
        _capsuleCollider.enabled = true;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    } 
    
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        _rb.velocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
        _moveDirection = playerControls.Player.Move.ReadValue<Vector2>();
        if (_moveDirection != Vector2.zero)
        {
            Move();
        }

        _anim.Move(_moveDirection);

        if(attacking)
        {
            timer += Time.deltaTime;
            if( timer >= timeToAttack)
            {
                timer = 0;
                attacking= false;
                _attackArea.SetActive(attacking);
                _attack1.SetActive(attacking);
            }
        }
    }
    public void DisableMovement()
    {
        playerControls.Player.Move.Disable();
        playerControls.Player.Attack.Disable();
    }

    private void Update()
    {
       
        if (isDashing)
        {
            return;
        }

        readMoveDirection = _moveDirection;
    }
}
