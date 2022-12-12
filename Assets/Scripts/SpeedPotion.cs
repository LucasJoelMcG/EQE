using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && playerMovement.canBuff)
        {
            if (collider.GetComponent<PlayerMovement>() != null)
            {
                PlayerMovement moveSpeed = collider.GetComponent<PlayerMovement>();
                moveSpeed.SpeedBuff();
                Destroy(gameObject);
            }
        }
    }
}
