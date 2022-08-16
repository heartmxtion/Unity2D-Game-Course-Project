using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public int destroy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Invoke("DestroyTime", destroy);
    }

    void Update()
    {

       transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void DestroyTime()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
           Destroy(gameObject);
    }

}
