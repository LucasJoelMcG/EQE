using UnityEngine;

public class AttackUITrigger : MonoBehaviour
{
    [SerializeField] private GameObject panel1;
    [SerializeField] private GameObject panel2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        Destroy(this.gameObject);
    }
}
