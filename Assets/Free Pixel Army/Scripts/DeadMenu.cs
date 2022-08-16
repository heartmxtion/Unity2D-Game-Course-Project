using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public GameObject player;
    public static bool activd;
    [SerializeField]
    GameObject deadMenu;
    void Start()
    {
        deadMenu.SetActive(false);
        activd = false;
    }
    void FixedUpdate()
    {
        if(HealthBar.health <= 0)
        {
            DeadMenuON();
        }
    }
    public void DeadMenuON() 
    {
        deadMenu.SetActive(true);
        activd = true;
        HealthBar.health = 0.1f;
    }
    public void DeadMenuOFF()
    {
        deadMenu.SetActive(false);
        activd = false;
        SceneManager.LoadScene(1);
        MoneyText.Coin = 0;
        EnemyCount.enemys = 0;
    } 

}
