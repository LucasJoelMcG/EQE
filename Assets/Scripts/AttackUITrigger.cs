using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackUITrigger : MonoBehaviour
{
    [SerializeField] private GameObject panel1;
    [SerializeField] private GameObject panel2;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        Destroy(this.gameObject);
    }
}
