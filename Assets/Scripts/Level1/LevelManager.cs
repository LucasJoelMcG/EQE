using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    private int enemies = 0;
    private bool isBossDefeated = false;
    [SerializeField] private GameObject finalBarrier;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void FixedUpdate()
    {
        if (enemies == 0 && isBossDefeated) { 
            finalBarrier.SetActive(false);
        }
    }

    public int getEnemies (){
        return enemies;
    }
    public void enemyDeleted()
    {
        enemies -= 1;
    }

    public void bossDefeated ()
    {
        if (!isBossDefeated)
            isBossDefeated=true;     
    }
}
