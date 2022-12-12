using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoUI : MonoBehaviour
{
    [SerializeField] private GameObject panelMovement;
    [SerializeField] private GameObject panelAttack1;
    [SerializeField] private GameObject panelAttack2;
    [SerializeField] private GameObject panelEliminateEnemies;
    [SerializeField] private GameObject panelHealPotion;
    [SerializeField] private GameObject triggerDamage;
    [SerializeField] private GameObject player;
    // [SerializeField] private GameObject potionHealth;
    private bool damaged;
    void Awake()
    {
        panelMovement.SetActive(true);
        panelAttack1.SetActive(false);
        panelAttack2.SetActive(false);
        panelEliminateEnemies.SetActive(false);
        panelHealPotion.SetActive(false);
        player = GameObject.Find("Player");
        damaged = false;
    }
    void Update()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] potions = GameObject.FindGameObjectsWithTag("Potion");

        if (enemies.Length == 3)
        {
            panelAttack1.SetActive(false);
            panelAttack2.SetActive(true);
        }
        if (enemies.Length == 2)
        {
            panelAttack2.SetActive(false);
            panelEliminateEnemies.SetActive(true);

        }
        if (enemies.Length == 1 && !damaged)
        {
            player.GetComponent<Health>().Damage(50);
            damaged = true;
        }
        if (enemies.Length == 0)
        {
            panelEliminateEnemies.SetActive(false);
            panelHealPotion.SetActive(true);

        }
        if (potions.Length == 0)
        {
            panelHealPotion.SetActive(false);
        }
    }
}
