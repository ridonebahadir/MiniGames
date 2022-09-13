using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    public GameObject wallParent;
    public GameObject money;
    public float yAxis;
    public List<int> value = new List<int>();
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject wall= Instantiate(wallParent, new Vector3(0, yAxis, 0), Quaternion.identity, transform);
            int random = Random.Range(0, 4);
            value.Add(random);
            wall.transform.GetChild(1).GetChild(random).gameObject.SetActive(true);
            yAxis -= 125;

        }
        Instantiate(money, new Vector3(0, yAxis, 0), Quaternion.identity, transform);

    }



}
