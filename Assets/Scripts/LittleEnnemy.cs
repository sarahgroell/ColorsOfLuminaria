using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleEnnemy : MonoBehaviour, Ennemy {

    public int curHealth;
    public int maxHealth = 3;

    public bool attack = false;
    public bool isDead = false;

    public GameObject collider;

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

        if (curHealth <= 0 || isDead)
        {            
            Die();
            isDead = false;        
        }
    }

    public void Die()
    {
        isDead = true;
        anim.SetBool("isDead", isDead);
        Destroy(gameObject.GetComponentInChildren<AttackConeLittleEnnemy>());
        Destroy(collider);
        gm.points += 10;
    }

    public void Attack()
    {
        if (!isDead)
        {
            StartCoroutine(PlayAttackAnim());
        }
    }

    IEnumerator PlayAttackAnim()
    {
        anim.Play("LittleEnnemy_Attack");
        yield return new WaitForSeconds(0.5f); // wait for 1/2 seconds.
        Die();
    }
    


    public void Damage(int dmg)
    {
        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("Player_RedFlash");
    }


}
