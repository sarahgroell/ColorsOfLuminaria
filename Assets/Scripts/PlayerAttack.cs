using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;
    private float attackedTimer = 0;
    private float attackCd = 0.3f;

    public Collider2D attackTrigger;

    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown("f") && !attacking)
        {
            attacking = true;
            attackedTimer = attackCd;
            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if(attackedTimer > 0)
            {
                attackedTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
        anim.SetBool("Attacking", attacking);
    }
}
