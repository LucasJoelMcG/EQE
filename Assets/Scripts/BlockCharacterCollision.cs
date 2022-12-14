using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCharacterCollision : MonoBehaviour
{
    public CapsuleCollider2D characterCollider;
    public CapsuleCollider2D characterBlockerCollider;
    void Start()
    {
        Physics2D.IgnoreCollision(characterCollider, characterBlockerCollider,true);
    }

    
}
