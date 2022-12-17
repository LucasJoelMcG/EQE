using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager3 : MonoBehaviour
{
    private int enemies = 0;
    //private bool isBossDefeated = false;
    [SerializeField] private GameObject finalBarrier;
    [SerializeField] private GameObject canvasBoss;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void FixedUpdate()
    {
        Debug.Log(enemies);
        if (enemies == 6)
        {
            finalBarrier.SetActive(false);
            canvasBoss.SetActive(true);
        }
        else if (enemies <= 0)
        {
            Loader.Load(Loader.Scene.CreditsScene);
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
