﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 50f;
    public float jumpPower;
    public float maxSpeed = 3;

    public bool grounded;
    public bool canDoubleJump;
    public bool wallSliding;
    public bool facingRight = true;

    public int curHealth;
    public int maxHealth = 5;

    private Rigidbody2D rb2d;
    private Animator anim;

    private GameMaster gameMaster;

    public Transform wallCheckPoint;
    public bool wallCheck;
    public LayerMask wallLayerMask;

	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        curHealth = maxHealth;
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

        if (Input.GetButtonDown("Jump") && !wallSliding)
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower/1.5f);
                }
            }
        }

        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if(curHealth <= 0)
        {
            Die();
        }


        if (!grounded)
        {
            wallCheck = Physics2D.OverlapCircle(wallCheckPoint.position, 0.1f,wallLayerMask);
            if(facingRight && Input.GetAxis("Horizontal") > 0.1f || !facingRight && Input.GetAxis("Horizontal") < 0.1f) { }
            {
                if (wallCheck)
                {
                    HandleWallSliding();
                }
            }
        }

        if(!wallCheck || grounded)
        {
            wallSliding = false;
        }
    }

    void HandleWallSliding()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, -0.7f);
        wallSliding = true;
        if (Input.GetButtonDown("Jump"))
        {
            if (facingRight)
            {
                rb2d.AddForce(new Vector2(-1.5f, 2) * jumpPower);
            }
            else
            {
                rb2d.AddForce(new Vector2(1.5f, 2) * jumpPower);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float h = Input.GetAxis("Horizontal");
       
        //Fake friction
        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }


        if (grounded)
        {
            rb2d.AddForce(Vector2.right * speed * h);
        }
        else
        {
            rb2d.AddForce(Vector2.right * speed/2 * h);
        }

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if(rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    public void Damage(int dmg)
    {
        if (curHealth - dmg > 0)
        {
            curHealth -= dmg;
            gameObject.GetComponent<Animation>().Play("Player_RedFlash");
        }
        else
            curHealth = 0;
        
    }
    public void Die()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            if(gameMaster.points > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", gameMaster.points);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highscore", gameMaster.points);
        }
        Application.LoadLevel(Application.loadedLevel);
    }


    public IEnumerator KnockBack(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        while(knockDur > timer)
        {
            timer += Time.deltaTime;
            rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
        }
        yield return 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            gameMaster.points += 1;
        }
    }

}
