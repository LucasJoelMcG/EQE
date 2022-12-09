using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] public int damage;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }

        if (collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            health.Damage(damage);
            collider.transform.Translate(new Vector3(transform.localScale.x*0.01f,0,0));

        }


    }
}
