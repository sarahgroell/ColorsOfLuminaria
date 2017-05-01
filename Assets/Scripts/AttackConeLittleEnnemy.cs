using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackConeLittleEnnemy : MonoBehaviour {

    public LittleEnnemy littleEnnemy;

    void Awake()
    {
        littleEnnemy = gameObject.GetComponentInParent<LittleEnnemy>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            littleEnnemy.Attack();
            col.GetComponent<Player>().Damage(1);
        }
    }
}
