using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Move : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 offset;
    public Vector3 startPos;
    public Vector3 startRot;
    public bool run;


    public Transform uv;
    public Transform glass;
    public bool isMoney;
    public bool isMagnifying;
    public bool isUv;
   

    private void Start()
    {
        if (isMoney)
        {
            StartMove();
        }
        else
        {
            startPos = transform.position;
            startRot = transform.rotation.eulerAngles;
        }
       
        
    }

    public void StartMove()
    {
        run = true;
        transform.GetComponent<BoxCollider>().enabled = true;
        transform.DOMove(Vector3.zero, 0.5f).OnComplete(() => {
            startPos = transform.position;
            startRot = transform.rotation.eulerAngles;

        });
    }

    private void OnMouseDown()
    {
        if (isUv)
        {
            glass.gameObject.SetActive(false);
        }
        if (isMagnifying)
        {
            uv.gameObject.SetActive(false);
        }
        if (run)
        {
            if (isMoney)
            {
                transform.localPosition = new Vector3(0, 2, 0);

            }
            if(isUv)
            {
                transform.DORotate(new Vector3(0, 0, 60), 1f);

            }
            if (isMagnifying)
            {
                transform.position += new Vector3(0, 5, 0);
                transform.DORotate(new Vector3(0, 180, 0), 1f);
            }
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        }



    }
    private void OnMouseDrag()
    {
        if (run)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = new Vector3(curPosition.x, transform.position.y, curPosition.z);
        }
         

        





    }
    private void OnMouseUp()
    {
       
        if (run)
        {
            transform.DOMove(startPos, 0.3f).OnComplete(()=> {

                if (isUv)
                {
                    glass.gameObject.SetActive(true);
                }
                if (isMagnifying)
                {
                    uv.gameObject.SetActive(true);
                }
            });
            transform.DORotate(startRot, 1f);

           
        }
        




    }
}
