using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEye : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] AIPath aIPath;
    void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }


    void Update()
    {
        sprite.flipX = aIPath.desiredVelocity.x <= 0.01f;
    }
}
