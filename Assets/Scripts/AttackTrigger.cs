using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int dmg =100;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger !=true && col.CompareTag("Ennemy"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
