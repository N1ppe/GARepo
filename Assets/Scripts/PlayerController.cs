using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    Rigidbody2D rb = null;
    float scaleX = 0;
    bool inAir = false;
    public float groundCheckDistance = 0.5f;
    public float jumpForce = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * Input.GetAxis("Horizontal") * speed + Vector2.up * rb.velocity.y;

        if(Input.GetAxis("Horizontal") != 0)
        {
            int direction = 1;
            if (Input.GetAxis("Horizontal") < 0)
            {
                direction = -1;
            }
            transform.localScale = new Vector3(scaleX * direction, transform.localScale.y, transform.localScale.z);
        }

        //Make sure char is on the ground by checking the distance from char downwards
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        //if there is ground close enough you arnt in air
        inAir = hit.collider == null;

        //If the char is on the ground and Jump so space is pushed the char jumps
        if (!inAir && Input.GetButtonDown("Jump"))
        {
            transform.position += Vector3.up * 0.1f;
            rb.AddForce(Vector2.up * jumpForce);
        }

    }
}
