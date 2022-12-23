using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{
    public int damage = 30;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyHealth>() != null)
        {
            //Debug.Log("Damage Enemigo");
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            health.Damage(damage);

        }
        if (collider.GetComponent<Chest>() != null)
        {
            //Debug.Log("Damage Enemigo");
            Chest health = collider.GetComponent<Chest>();
            health.Damage(damage);

        }

    }
}
