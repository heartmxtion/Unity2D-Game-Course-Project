using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyCount : MonoBehaviour
{
    Text text;
    public static int enemys;
    void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        text.text = enemys.ToString();
    }
}
