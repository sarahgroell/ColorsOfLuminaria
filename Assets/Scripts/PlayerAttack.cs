using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public AudioClip attackSong;
    private bool attacking = false;
    private float attackedTimer = 0;
    private float attackCd = 0.3f;

    public Collider2D attackTrigger;

    public float bulletSpeed = 100;
    public float bulletTimer;
    public float shootInterval;


    public GameObject bullet;
    public Transform shootPointLeft;
    private Player player;
    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        player = gameObject.GetComponent<Player>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown("f") && !attacking)
        {
            attacking = true;
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = attackSong;
            audio.Play();
            attackedTimer = attackCd;
            //attackTrigger.enabled = true;
            Attack();
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
                //attackTrigger.enabled = false;
            }
        }
        anim.SetBool("Attacking", attacking);
    }

    public void Attack()
    {
        Vector2 direction;
        if (player.facingRight)
        {
            direction = new Vector2(1, 0);
        }
        else
        {
            direction = new Vector2(-1, 0);
        }
        direction.Normalize();

       GameObject bulletClone;
       bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation);
       bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;               

    }
}
