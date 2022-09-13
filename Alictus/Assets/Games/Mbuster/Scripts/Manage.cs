using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Manage : MonoBehaviour
{
    public int random;
    public int randomUv;
    public int randomGlass;
    public Transform uvMoney;
    public Transform glass;
    
    private void Start()
    {
        RandomMoney();


    }
    public void RandomMoney()
    {
        uvMoney.gameObject.SetActive(true);
        for (int i = 0; i < uvMoney.childCount; i++)
        {
            uvMoney.GetChild(i).gameObject.SetActive(false);
        }
        randomUv = Random.Range(0, uvMoney.childCount);
        uvMoney.GetChild(randomUv).gameObject.SetActive(true);



        glass.gameObject.SetActive(true);
        for (int i = 0; i < glass.childCount; i++)
        {
            glass.GetChild(i).gameObject.SetActive(false);
        }
        randomGlass = Random.Range(0, glass.childCount);
        glass.GetChild(randomGlass).gameObject.SetActive(true);


        if (randomGlass==1&&randomUv==1)
        {
            random = 1;
        }
        else
        {
            random = 0;
        }
    }
}
