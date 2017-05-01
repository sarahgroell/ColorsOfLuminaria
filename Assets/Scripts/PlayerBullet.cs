using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true)
        {
            if (col.CompareTag("Ennemy"))
            {
                col.GetComponentInParent<TurretStupid>().Damage(10);
                Destroy(gameObject);
            }
           
        }
        if (col.tag == "Walls")
        {
            Destroy(gameObject);
        }
    }
}
