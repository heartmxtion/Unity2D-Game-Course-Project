using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Walk();
        Reflect();
        Jump();
        CheckingGround();
    }

    public Vector2 moveVector;
    public float speed = 2f;
    public bool faceRight = true;
    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            
            faceRight = !faceRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public float jumpForce = 210f;
    private bool jumpControl;
    private int jumpIteration = 0;
    public int jumpValueIteration = 3;
    //public int jumpForce = 7;
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Physics2D.IgnoreLayerCollision(9, 10, true);
            Invoke("IgnoreLayerOff", 0.5f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
              if (onGround)
              {
                  jumpControl = true;
              }
              else
              {
                  jumpControl = false;
              }
              if (jumpControl)
              {
                  if (jumpIteration++ < jumpValueIteration)
                  {
                    rb.velocity = new Vector2(rb.velocity.x, 10);
                    rb.AddForce(Vector2.up * jumpForce / jumpIteration);
                    
                  }
              }
              else
              {
                  jumpIteration = 0;
              }
            //rb.velocity = new Vector2(rb.velocity.x, 0);
            //rb.AddForce(Vector2.up * jumpForce * 50);
        }
    }

    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }

    void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            HealthBar.health -= 20f;
        }
        if (other.CompareTag("DieZone"))
        {
            HealthBar.health -= 100f;
        }
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(2);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Moving platform"))
        {
            this.transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Moving platform"))
        {
            this.transform.parent = null;
        }
    }

}
