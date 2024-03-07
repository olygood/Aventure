using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    //GamePlay speedX 3,speedY 4, moveY 80, mass 1.3
    public float speedX = 3.0f;
    public float speedY = 4.0f;
    public float moveY = 80.0f;
    bool isJumping = false;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = 1.3f;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        //bool spaceOk = Input.GetKeyDown(KeyCode.Space);
        //float moveY = Input.GetAxis("Vertical");
        Vector2 movementX = new Vector2(moveX,0.0f);

        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector2(0.0f, moveY) * speedY, ForceMode2D.Force);
            isJumping = true;
        }
        /*{
            rb.AddForce(new Vector2(0.0f, moveY) * speedY, ForceMode2D.Force);
        }
        */
        //Vector2 movementY = new Vector2(0.0f,moveY);
        //Debug.Log("moveX: " + moveX + ", moveY: " + moveY);
        
        rb.velocity = new Vector2(moveX * speedX, rb.velocity.y);
        //rb.AddForce(movementY * speedY* Time.deltaTime, ForceMode2D.Impulse);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }   
}
