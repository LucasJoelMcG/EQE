using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class LevelManager3 : MonoBehaviour
{
    private int enemies = 0;
    //private bool isBossDefeated = false;
    [SerializeField] private GameObject finalBarrier;
    [SerializeField] private GameObject canvasBoss;

    [Header("Ending")]
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 2f;
    [SerializeField] private PlayerMovement playerMovement;

    private bool levelFinished = false;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;
    }

    private void Update()
    {
        if (Keyboard.current.backspaceKey.wasPressedThisFrame ||
            Keyboard.current.deleteKey.wasPressedThisFrame)
        {
            KillAllEnemies();
        }
    }

    private void KillAllEnemies()
    {
        GameObject[] enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemiesInScene)
        {
            EnemyHealth health = enemy.GetComponent<EnemyHealth>();

            if (health != null)
            {
                health.Damage(999999);
            }
        }
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
            levelFinished = true;
            StartCoroutine(EndLevel());
        }
    }

    private IEnumerator EndLevel()
    {
        playerMovement.DisableMovement();
        playerMovement.StopMovement();

        float timer = 0f;

        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;

            color.a = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = color;

            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;

        Time.timeScale = 0f;

        Loader.Load(Loader.Scene.EndingScene);
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
