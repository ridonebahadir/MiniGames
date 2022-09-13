using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Bone : MonoBehaviour
{
    public bool isActive = false;
    public Color activeColor = new Color();
    public Transform bone;
    public Vector3 startRot;
    public bool isHand;
    public bool isLeft;
   
    private void Start()
    {

        startRot =bone.transform.localEulerAngles;
        
    }
    private void Update()
    {
      

        GetComponent<MeshRenderer>().material.color = activeColor;
    }
    Vector3 currentPositon;
    Vector3 deltaPositon;
    Vector3 lastPositon;
    private void OnMouseDrag()
    {
        currentPositon = Input.mousePosition;
        deltaPositon = currentPositon - lastPositon;
        lastPositon = currentPositon;
        if (isHand)
        {

            if (isLeft)
            {
                bone.transform.Rotate(deltaPositon.x / 5, 0, 0f);

            }
            else
            {
                bone.transform.Rotate(-deltaPositon.x / 5, 0, 0f);

            }
        }
        else
        {
            bone.transform.Rotate(deltaPositon.y / 5, 0, 0f);
        }
    }


    private void OnMouseDown()
    {
        isActive = true;
    }
   public void TurnStartPos()
    {
        bone.DOLocalRotate(startRot, 1f).SetEase(Ease.OutSine);
    }
    
}