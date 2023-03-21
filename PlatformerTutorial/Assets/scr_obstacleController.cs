using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_obstacleController : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public Animator anim;
    public float speed = 0f;
    private float startTime;
    private float journeyLength;
    private bool facingRight = true;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector2.Distance(startPoint.position, endPoint.position);
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracDist = distCovered / journeyLength;
        transform.position = Vector2.Lerp(startPoint.position, endPoint.position, Mathf.PingPong(fracDist, 1));
        
        if(facingRight == true && transform.position == endPoint.position)
        {
            Flip();
        }
        else if (facingRight == false && transform.position == startPoint.position)
        {
            Flip();
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
