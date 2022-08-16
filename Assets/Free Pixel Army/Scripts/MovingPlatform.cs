using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float speed = 3f;
    public float minX;
    public float maxX;

    bool moveingRight = true;
    void Update()
    {
        if (transform.position.x > maxX)
        {
            moveingRight = false;
        }
        else if (transform.position.x < minX)
        {
            moveingRight = true;
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
