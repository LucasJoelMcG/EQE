using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float distanceBetween;
    [SerializeField] private float attackDistance;
    private SpriteRenderer _spriteRenderer;
    private PlayerAnimation _anim;
    private AudioSource _audioSword;
    private GameObject _attackArea = default;
    private GameObject _attack1 = default;
    private EnemyHealth _enemyHealth;
    private bool attacking = false;
    private float distance;
   // private float timeToAttack = 1f;
   // private float timer = 0f;

    public Rigidbody2D _rb;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    private float timeLeft;
    public float timeToMove = 10f;
    // private float playerHealth;
    // Start is called before the first frame update

    [SerializeField] private GameObject sAttack;
    private bool sAttacking = false;
    private bool canMove = true;
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _anim = GetComponent<PlayerAnimation>();
        _attackArea = transform.GetChild(0).gameObject;
        _attack1 = transform.GetChild(1).gameObject;
        _audioSword = GetComponentInChildren<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
        _enemyHealth = GetComponent<EnemyHealth>();
        //playerHealth = GetComponent<Health>().readHealth;
    }
    void Start()
    {
        timeLeft = 0f;
        CalculateNewMovementVector();
    }

    void CalculateNewMovementVector() //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
    {
        movementDirection = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
        movementDirection.Normalize();
        movementPerSecond = movementDirection * speed;
    }
    private void Move()
    {

        if (transform.position.x != 0f)
        {
            Flip();
        }
    }

    private void Flip()
    {
        if (player.transform.position.x < transform.position.x)
        {
            _spriteRenderer.flipX = true;
            _attackArea.transform.localScale = new Vector2(-1f, 1f);
            _attack1.transform.localPosition = new Vector2(-1f, 0f);
        }
        if (player.transform.position.x > transform.position.x)
        {
            _spriteRenderer.flipX = false;
            _attackArea.transform.localScale = new Vector2(1f, 1f);
            _attack1.transform.localPosition = new Vector2(1f, 0f);
        }
       
    }
    IEnumerator Attack()
    {
        _anim.Attack();
        attacking = true;
        _attackArea.SetActive(true);
        _attack1.SetActive(true);
        _audioSword.Play();
        yield return new WaitForSeconds(1.2f);
        _attackArea.SetActive(false);
        _attack1.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        attacking = false;
        if (GameObject.Find("Player") != null)
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * 0.01f);
    }

    IEnumerator SpecialAttack()
    {
        sAttacking = true;
        canMove = false;
        _anim.SpecialAttack();
       // _audioSword.Play();
        yield return new WaitForSeconds(1.2f);
        // _attackArea.SetActive(true); despues de 1.4 s activo el collider
        sAttack.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        sAttack.SetActive(false); //despues de 0.1 s desactivo el collider
        canMove = true;
        //_attack1.SetActive(true);
        yield return new WaitForSeconds(5f); //cooldown
        sAttacking = false;
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (_enemyHealth.readHealth > 0f)
        {
            if (distance < attackDistance)
            {
                if (!attacking)
                    StartCoroutine(Attack());
            }
            else
            {
                if (distance < distanceBetween && distance > 0.5f && !sAttacking)
                {
                    StartCoroutine(SpecialAttack());
                }
                if (distance < distanceBetween && distance > 0.5f && canMove)
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                    Move();
                    _anim.Move(transform.position);
                }
                else
                {
                    if (distance > distanceBetween)
                    {
                        if (Time.time - timeLeft > timeToMove)
                        {
                            timeLeft = Time.time;
                            CalculateNewMovementVector();
                        }
                        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
                        _anim.Move(transform.position);
                        Move();
                    }
                }
            }
        }
    }
}
