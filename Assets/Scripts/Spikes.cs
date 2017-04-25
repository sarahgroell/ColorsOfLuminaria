using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); 
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Player"))
        {
            player.Damage(3);
            StartCoroutine(player.KnockBack(0.02f,150,player.transform.position));
        }
	}
}
