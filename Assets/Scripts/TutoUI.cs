using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutoUI : MonoBehaviour
{
    [SerializeField] private GameObject panelMovement;
    [SerializeField] private GameObject panelAttack1;
    [SerializeField] private GameObject panelAttack2;
    [SerializeField] private GameObject panelEliminateEnemies;
    [SerializeField] private GameObject panelHealPotion;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject DropItemPrefab;
    [SerializeField] private LevelManager LevelManager;
    private int enemies = 0;
    private bool damaged = false;
    private int potions = 0;
    private bool potionSpawned = false;
    void Awake()
    {
        panelMovement.SetActive(true);
        panelAttack1.SetActive(false);
        panelAttack2.SetActive(false);
        panelEliminateEnemies.SetActive(false);
        panelHealPotion.SetActive(false);
        LevelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    void FixedUpdate()
    {
        enemies = LevelManager.getEnemies();
        if (enemies == 3)
        {
            panelAttack1.SetActive(false);
            panelAttack2.SetActive(true);
        }
        if (enemies == 2)
        {
            panelAttack2.SetActive(false);
            panelEliminateEnemies.SetActive(true);

        }
        if (enemies == 1 && !damaged)
        {
            player.GetComponent<Health>().Damage(30);
            damaged = true;
        }
        if (enemies == 0 && !potionSpawned)
        {
            panelEliminateEnemies.SetActive(false);
            panelHealPotion.SetActive(true);
            Instantiate(DropItemPrefab, new Vector3(5, 0, 0), Quaternion.identity, null);
            potions++;
            potionSpawned = true;
        }
        if (potions == 1 && player.GetComponent<Health>().health != 100)
        {
            panelHealPotion.SetActive(false);
            potions--;
        }
    }
}