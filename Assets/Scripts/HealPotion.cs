using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    Health playerHealth;
    [SerializeField] private int heal = 30;

    private void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && playerHealth.readHealth < playerHealth.readMaxHealth)
        {
            if (collider.GetComponent<Health>() != null)
            {
                Health health = collider.GetComponent<Health>();
                health.Heal(heal);
                Destroy(gameObject);
            }
        }
    }
}
