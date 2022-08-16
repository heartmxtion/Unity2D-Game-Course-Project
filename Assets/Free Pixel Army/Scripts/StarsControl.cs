using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsControl : MonoBehaviour
{
    public GameObject star1, star2, star3;
    public static int open_star1, open_star2, open_star3;
    void Start()
    {
        open_star1 = PlayerPrefs.GetInt("stars1", 1);
        open_star2 = PlayerPrefs.GetInt("stars2", 1);
        open_star3 = PlayerPrefs.GetInt("stars3", 1);
    }


    void Update()
    {
        if(open_star1 == 1)
        {
            star1.SetActive(false);
        }
        if(open_star1 == 2)
        {
            star1.SetActive(true);
        }
        if (open_star2 == 1)
        {
            star2.SetActive(false);
        }
        if (open_star2 == 2)
        {
            star2.SetActive(true);
        }
        if (open_star3 == 1)
        {
            star3.SetActive(false);
        }
        if (open_star3 == 2)
        {
            star3.SetActive(true);
        }


        if((MoneyText.Coin >= 3)&&(EnemyCount.enemys >= 1))
        {
            OpenStar1();
        }
        if ((MoneyText.Coin >= 6)&&(EnemyCount.enemys >= 7))
        {
            OpenStar2();
        }
        if ((MoneyText.Coin >= 10)&&(EnemyCount.enemys >= 14))
        {
            OpenStar3();
        }

      
    }
    public void OpenStar1()
    {
        open_star1 = 2;
        PlayerPrefs.SetInt("stars1", open_star1);
    }
    public void OpenStar2()
    {
        open_star2 = 2;
        PlayerPrefs.SetInt("stars2", open_star2);
    }
    public void OpenStar3()
    {
        open_star3 = 2;
        PlayerPrefs.SetInt("stars3", open_star3);
    }
    
    public void goToMainMenu()
    {
        SceneManager.LoadScene(0);
        MoneyText.Coin = 0;
        EnemyCount.enemys = 0;
    }
}
