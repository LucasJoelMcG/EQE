using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightningBehavior : MonoBehaviour
{
    [SerializeField] CircleCollider2D myCollider;
    void Awake()
    {
        gameObject.SetActive(true);
        StartCoroutine(selfDestruct());
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(0.4f);
        myCollider.enabled = true;
        yield return new WaitForSeconds(0.1f);
        myCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
