using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private Player player;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag != "Dialogue")
            player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag != "Dialogue")
            player.grounded = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag != "Dialogue")
            player.grounded = true;
    }
}