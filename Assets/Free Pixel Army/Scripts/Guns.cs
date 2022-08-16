using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public GameObject Bullet1;
    public Transform shotpos;

    public float StartTimeFire;
    private float TimeFire;

    void Start()
    {
        TimeFire = StartTimeFire;    
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(TimeFire <= 0)
            {
                Instantiate(Bullet1, shotpos.transform.position, transform.rotation);
                TimeFire = StartTimeFire;
            }
            else
            {
                TimeFire -= Time.deltaTime;
            }
        }
    }
}
