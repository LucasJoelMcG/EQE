using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int _maxHealth;
    private GameObject enemies;
    public GameObject healthBarUI;
    public Slider slider;
    private PlayerAnimation _anim;
    public int readHealth;        //Variable de lectura para Health
    public int readMaxHealth;     //Variable de lectura para _maxHealth
    [SerializeField] private GameObject DropItemPrefab;
    private int randomNumber;
    [SerializeField] private int plusProbability;


    private void Awake()
    {
        _anim = GetComponent<PlayerAnimation>();
        enemies = GameObject.Find("LevelManager");
           
    }
    private void Start()
    {
        health = _maxHealth;
        slider.value = CalculateHealth();
    }
    void Update()
    {
        readHealth = health;
        readMaxHealth = _maxHealth;
        slider.value = CalculateHealth();
        if (health < _maxHealth)
        {
            healthBarUI.SetActive(true);
        }
    }
    int CalculateHealth()
    {
        return health;
    }
    public void Damage(int amount)
    {
        if (amount < 1)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }
        this.health -= amount;

        if (health > 1)
        {
            _anim.Hit();
        }

        Debug.Log("Health: " + health);
        if (health < 1)
        {
            _anim.Die();
            Debug.Log("Animacion Dead");
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Heal");
        }

        bool wouldBeOverMaxHealth = health + amount > _maxHealth;


        if (wouldBeOverMaxHealth)
        {
            this.health = _maxHealth;
        }
        else
        {
            this.health += amount;
        }
        Debug.Log("Health: " + health);
    }

    private void Die()
    {
        Debug.Log("I am Dead");
        Destroy(gameObject, 1.5f);
        GetComponent<Collider2D>().enabled = false;
        DropItem();
        enemies.GetComponent<LevelManager>().enemyDeleted();

    }

    private void DropItem()
    {
        randomNumber = Random.Range(0, 100)+ plusProbability;
        Debug.Log(randomNumber);
        if (randomNumber > 50) { 
            GameObject Drop = Instantiate(DropItemPrefab, transform.position, Quaternion.identity, null);
        
        }

    }
}
