using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public Transform colorRings;
    private int child;
    public bool turn;
    DragObj dragObj;
    public GameObject ghost;
    private void Update()
    {
        child = colorRings.childCount;
        if (child>0)
        {
            for (int i = 0; i < child; i++)
            {
                colorRings.GetChild(i).GetComponent<MeshCollider>().enabled = false;
            }
            dragObj = colorRings.GetChild(child - 1).GetComponent<DragObj>();
            dragObj.GetComponent<MeshCollider>().enabled = true;

            if (turn)
            {
                if (GameManager.handleId == dragObj.id)
                {
                   
                    if (GameManager.bodyId!=transform.GetSiblingIndex())
                    {
                        dragObj.ghost.gameObject.SetActive(true);
                        
                            GameManager.handleObj.startPos = dragObj.ghost.gameObject.transform.position;
                            GameManager.handleObj.parentt = dragObj.ghost.transform.parent.parent;
                        
                     
                        
                       
                    }
                    else
                    {
                        //GameManager.handleObj.target.position = GameManager.handleObj.startTarget;
                    }
                


                }
            }
            else
            {
                for (int i = 0; i < child; i++)
                {
                    colorRings.GetChild(i).GetChild(0).gameObject.SetActive(false);
                }
               
              
               
              

            }
        }
        else
        {
            if (turn)
            {
                ghost.gameObject.SetActive(true);
                GameManager.handleObj.startPos = ghost.gameObject.transform.position;
                GameManager.handleObj.parentt = colorRings.transform;
            }
            else
            {
                ghost.gameObject.SetActive(false);
            }
           
        }


    }
}
