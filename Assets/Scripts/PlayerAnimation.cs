
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    public void Move(Vector2 move)
    {
        if (move.x != 0 || move.y != 0)
            anim.SetFloat("Move", Mathf.Abs(1));
        else
            anim.SetFloat("Move", Mathf.Abs(0));
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    
    }

    public void SpecialAttack()
    {
        anim.SetTrigger("SpecialAttack");

    }

    public void Die()
    {
        anim.SetTrigger("Die");

    }
    public void Hit()
    {
        anim.SetTrigger("Hit");

    }



}
