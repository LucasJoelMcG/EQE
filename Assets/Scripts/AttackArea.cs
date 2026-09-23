using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("PLAYER ENTER");
        Health playerHealth=collider.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.Damage(damage);
        }
     

    }
}
