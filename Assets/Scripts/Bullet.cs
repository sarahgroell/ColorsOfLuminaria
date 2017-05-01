using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float life = 2.0f;

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger != true)
        {
            if (col.CompareTag("Player"))
            {
                col.GetComponent<Player>().Damage(1);
                Destroy(gameObject);
            }
        }
    }
}
