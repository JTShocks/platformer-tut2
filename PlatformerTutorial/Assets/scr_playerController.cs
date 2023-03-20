using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_playerController : MonoBehaviour
{
private Rigidbody2D rb;
public float speed;
public TextMeshProUGUI score;
public TextMeshProUGUI lives;
private int scoreValue = 0;
private int livesCount = 0;
public AudioClip itemGrab;
public AudioClip musicClip;
public AudioSource musicSource;
public AudioSource stageMusic;

public Animator anim;
private bool facingRight = true;
private bool isJumping;
private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        score.text = scoreValue.ToString();
        livesCount = 3;
        lives.text = livesCount.ToString();
        stageMusic.clip = musicClip;
        stageMusic.Play();
        stageMusic.loop = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rb.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

        if(hozMovement != 0)
        {
            anim.SetInteger("State", 2);
        }
        else
        {
            anim.SetInteger("State", 0);
        }
        if(rb.velocity.y > 0)
        {
           anim.SetInteger("State", 3);
        }
        if (rb.velocity.y < 0){
            anim.SetInteger("State",4);
        }
        if (rb.velocity.y == 0)
        {
            if(hozMovement != 0)
        {
            anim.SetInteger("State", 2);
        }
        else
        {
            anim.SetInteger("State", 0);
        }}
        
        if (facingRight == false && hozMovement > 0)
        {
            Flip();

        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();

        }
    }
        private void OnTriggerEnter2D(Collider2D trigger)
    {
       if (trigger.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            musicSource.clip = itemGrab;
            musicSource.Play();
            Destroy(trigger.gameObject);
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(new Vector2(0, 3), ForceMode2D.Impulse); //the 3 in this line of code is the player's "jumpforce," and you change that number to get different jump behaviors
            }
        }
    }
    private void Flip()
    {
        facingRight =! facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x *-1;
        transform.localScale = Scaler;
    }

}
