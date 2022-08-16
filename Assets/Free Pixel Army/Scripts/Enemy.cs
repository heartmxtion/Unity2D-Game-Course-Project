using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sr;
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        onGround = true;
    }


    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasePlayer();
        }
        if (onGround == false)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        if (onGround == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        CheckingGround();
    }
    //public Vector2 moveVector;
    void ChasePlayer()
    {
        if (transform.position.x - 0.3 < player.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetFloat("moveX", Mathf.Abs(rb.velocity.x));
        }
        else if (transform.position.x + 0.3 > player.position.x)
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = true;
            anim.SetFloat("moveX", Mathf.Abs(rb.velocity.x));
        }
    }
    //bool isGrounded = false;
    void StopChasePlayer()
    {
        rb.velocity = new Vector2(0, 0);
        anim.SetFloat("moveX", Mathf.Abs(rb.velocity.x));
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name.Equals("Ground"))
    //    {
    //        isGrounded = true;
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    isGrounded = false;
    //}
    //private void EnemysOnGroundFalls()
    //{
    //    if(isGrounded == false)
    //    {
    //       // this.rb.fre
    //    }
    //}
    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }
}
