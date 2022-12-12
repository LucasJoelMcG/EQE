using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPotion : MonoBehaviour
{
    [SerializeField] private GameObject DropItemPrefab;
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies == null || enemies.Length == 0)
        {
            GameObject Drop = Instantiate(DropItemPrefab, transform.position, Quaternion.identity, null);
            Destroy(gameObject);
        }
    }
}
