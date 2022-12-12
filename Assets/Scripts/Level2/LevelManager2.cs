using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager2 : MonoBehaviour
{
    private int enemies = 0;
    [SerializeField] private GameObject finalBarrier1;
    [SerializeField] private GameObject finalBarrier2;


    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

    }

    void FixedUpdate()
    {
        if (enemies == 0)
        {
            finalBarrier2.SetActive(false);
        }
        if (enemies == 4)
        {
            finalBarrier1.SetActive(false);
        }
    }

    public int getEnemies()
    {
        return enemies;
    }
    public void enemyDeleted()
    {
        enemies -= 1;
    }

    //public void bossDefeated()
    //{
    //    if (!isBossDefeated)
    //        isBossDefeated = true;
    //}
}
