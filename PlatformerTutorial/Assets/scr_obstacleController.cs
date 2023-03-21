using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_obstacleController : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public SpriteRenderer obstacleSprite;
    public Animator anim;
    public float speed = 0f;
    private float startTime;
    private float journeyLength;
    private bool facingRight = true;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector2.Distance(startPoint.position, endPoint.position);
        obstacleSprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracDist = distCovered / journeyLength;
        transform.position = Vector2.Lerp(startPoint.position, endPoint.position, Mathf.PingPong(fracDist, 1));

        if(facingRight == true && distCovered == journeyLength)
        {
            Flip();
            obstacleSprite.flipX = true;

        }
        else if (facingRight == false && transform.position == startPoint.position)
        {
            Flip();
            obstacleSprite.flipX = false;
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
