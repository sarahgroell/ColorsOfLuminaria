using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackConeStupid : MonoBehaviour {
    public TurretStupid turretStupid;

    void Awake()
    {
        turretStupid = gameObject.GetComponentInParent<TurretStupid>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
           
           turretStupid.Attack();
            
        }
    }
}
