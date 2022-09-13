using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;

[RequireComponent(typeof(MeshCollider))]

public class DragObj : MonoBehaviour
{
    public GameObject ghost;
    private Vector3 screenPoint;
    private Vector3 offset;
    public Vector3 startPos;
   
    bool run;
    public int id;
    
    private DragObj dragObj;
    
    private void Start()
    {
        dragObj = GetComponent<DragObj>();
        ghost = transform.GetChild(0).gameObject;
        


    }



    void OnMouseDown()
    {
       
        parentt = transform.parent;
        startPos = transform.position;
        transform.DOMove(transform.parent.position+new Vector3(0,10,0), 0.2f).OnComplete(() => {
          
            run = true;
        });
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        GameManager.handleId = id;
        GameManager.handleObj = dragObj;
        GameManager.bodyId = transform.parent.parent.transform.GetSiblingIndex();
        


    }

    void OnMouseDrag()
    {

        if (run)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.DOMove(curPosition, 0.4f);
        }


      



    }
    public Transform parentt;
    private void OnMouseUp()
    {
       
       
        run = false;
        transform.DOMove(parentt.position + new Vector3(0, 10, 0), 0.4f).OnComplete(() =>
            transform.DOMove(startPos, 0.2f).OnComplete(() => {
                transform.parent = parentt;
                GameManager.handleId = 0;
                LevelControl();
            }));




    }
    public int child;
    private void LevelControl()
    {
         child = transform.parent.childCount-1;
        if (child>2)
        {
            for (int i = child; i > 0; i--)
            {
                if (transform.parent.GetChild(i).GetComponent<DragObj>().id == transform.parent.GetChild(i - 1).GetComponent<DragObj>().id)
                {
                    Debug.Log("win");
                }
                else
                {
                    Debug.Log("daha degil");
                }

            }
        }

      
    }
}