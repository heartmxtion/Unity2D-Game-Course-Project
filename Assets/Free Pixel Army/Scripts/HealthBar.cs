using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    public Image healthbar;
    public Image healthBarEffect;
    float maxhealth = 100f;
    public static float health;
    private float healthspeed = 0.003f;
    void Start()
    {
        healthbar = GetComponent<Image>();
        health = maxhealth;
    }
    void Update()
    {
        healthbar.fillAmount = health / maxhealth;
        if(healthBarEffect.fillAmount > healthbar.fillAmount)
        {
            healthBarEffect.fillAmount -= healthspeed;
        }
        else
        {
            healthBarEffect.fillAmount = healthbar.fillAmount;
        }
        if(healthbar.fillAmount <= 0)
        {
            Destroy(player);
        }
    }
}
