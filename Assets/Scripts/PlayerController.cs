using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float runSpeed=2;
    
    public float jumpSpeed = 3;
    public spriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    private GroundSensor sensor;
    float horizontal;

    Rigidbody2D rb2D;
    void Start()
    {
        spriteRenderer = GetComponent<spriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>(); 
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }

        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }

        if(Input.GetButtonDown("Jump") && sensor.isGrounded)
        {
            rBody.AddForce(vector2.up * jumpforce, ForceMode2D.impulse);
        }    
        
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity= new Vector2(runSpeed, rb2D.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity= new Vector2(-runSpeed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity=new Vector2(0, rb2D.velocity.y);
        }
        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
        
    }
}
