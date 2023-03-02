using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerController : MonoBehaviour
{
private Rigidbody2D rb;
public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rb.transform.position = (rb.transform.position) + (new Vector3(hozMovement * speed * Time.deltaTime, vertMovement * speed * Time.deltaTime, 0));
    }
}
