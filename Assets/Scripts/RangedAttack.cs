using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField] private Vector2 speed = new Vector2(3f,0);
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject destroyEffect;
    Rigidbody2D _rb;
    public int damage = 30;

    private void Awake()
    {
      _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        _rb.velocity = new Vector2(speed.x * -transform.localScale.x, speed.y);
        Invoke("DestroySlash", lifeTime);

    }

    void DestroySlash()
    {
        Destroy(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            health.Damage(damage);
            Destroy(gameObject);

        }


    }
}
