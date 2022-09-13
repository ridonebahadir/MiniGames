using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float downSpeed;
    public List<Bone> bones;
    public SpawnWall spawnWall;
    int nextWall;
    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime*downSpeed,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="LaserEnd")
        {
            TurnStartPos();
           
            for (int i = 0; i < bones.Count; i++)
            {
                bones[i].activeColor = Color.green;
            }
            switch (spawnWall.value[nextWall])
            {
                case 0:
                    bones[0].activeColor = Color.red;
                    bones[1].activeColor = Color.red;
                    break;
                case 1:
                    bones[1].activeColor = Color.red;
                    bones[2].activeColor = Color.red;
                    break;
                case 2:
                    bones[2].activeColor = Color.red;
                    bones[3].activeColor = Color.red;
                    break;
                case 3:
              
                    bones[4].activeColor = Color.red;
                    break;
               
            }
            nextWall++;
        }
    }
    void TurnStartPos()
    {
        for (int i = 0; i < bones.Count; i++)
        {
            bones[i].TurnStartPos();
        }
    }
}
