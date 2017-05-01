using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStupid : MonoBehaviour, Ennemy {

    public int curHealth;
    public int maxHealth = 3;

    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public bool awake = false;
    public bool isDead = false;

    public GameObject bullet;
    public Transform target, shootPointLeft;
    public Animator anim;

    private GameMaster gm;


    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        anim.SetBool("Awake", awake);

        RangeCheck();

        if (curHealth <= 0)
        {
            isDead = true;
            anim.SetBool("isDead", isDead);
            Destroy(gameObject.GetComponentInChildren<BoxCollider2D>());
            gm.points += 10;
        }
    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < wakeRange)
        {
            awake = true;
        }
        if (distance > wakeRange)
        {
            awake = false;
        }
    }


    public void Attack()
    {
        if (!isDead)
        {
            bulletTimer += Time.deltaTime;

            if (bulletTimer >= shootInterval)
            {
                Vector2 direction = target.transform.position - transform.position;
                direction.Normalize();

                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation);
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletTimer = 0;

            }
        }
       
    }


    public void Damage(int dmg)
    {
        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("Player_RedFlash");
    }


}
