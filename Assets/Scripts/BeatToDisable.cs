using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatToDisable : MonoBehaviour
{
     void Awake()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            Debug.Log("No game objects are tagged with 'Enemy'");
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies == null || enemies.Length == 0)
            {
            gameObject.SetActive(false);
        }
    }
}
