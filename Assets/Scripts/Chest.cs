using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int _maxHealth;
    private PlayerAnimation _anim;
    [SerializeField] private GameObject HealItemPrefab;
    [SerializeField] private GameObject SpeedItemPrefab;
    private int randomNumber;
    [SerializeField] private int plusProbability;
    // Start is called before the first frame update

    private void Awake()
    {
        _anim = GetComponent<PlayerAnimation>();
    }
    void Start()
    {
        health = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        Debug.Log("I am Dead");
        Destroy(gameObject, 1.5f);
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1.4f);
        DropItem();

    }

    private void DropItem()
    {
        randomNumber = Random.Range(0, 100) + plusProbability;
        Debug.Log(randomNumber);
        if (randomNumber > 50)
        {
            GameObject Drop = Instantiate(HealItemPrefab, transform.position, Quaternion.identity, null);

        }
        if (randomNumber < 50)
        {
            GameObject Drop = Instantiate(SpeedItemPrefab, transform.position, Quaternion.identity, null);

        }
    }
}

