using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Touch : MonoBehaviour
{

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    public Animator anim;
    public int lastDirection;
    public int direction;
    public Transform arrows;
    public GameObject arrow;
    public SpriteRenderer box;
    GameObject cloneArrow;
    private Sequence sequence;
    private Guid uid;
    public SpriteRenderer poses;
    public Transform posesParent;
    public Sprite[] sprite;
    public int amount;
    public Transform confetti;
    public Transform glow;
    private void Start()
    {
      
        for (int i = 0; i < 5; i++)
        {
            Instantiate(arrow, arrows);

        }
        StartCoroutine(RandomDirection());
    }
    private void Update()
    {
        Swipe();
        
       
      
    }


    bool run = true;
    IEnumerator RandomDirection()
    {
        while (run)
        {
            box.color = Color.white;
            UniqueRandomInt(1, 5);

            cloneArrow = Instantiate(arrow, arrows);
            sequence = DOTween.Sequence();
            sequence.Append(cloneArrow.transform.DOLocalMove(new Vector3(-2,0,0), 2f));
            uid = System.Guid.NewGuid();
            sequence.id = uid;
            switch (lastDirection)
            {
                case 1:
                    cloneArrow.transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
                case 2:
                    cloneArrow.transform.eulerAngles = new Vector3(0, 0, 180);
                    break;
                case 3:
                    cloneArrow.transform.eulerAngles = new Vector3(0, 0, 90);
                    break;
                case 4:
                    cloneArrow.transform.eulerAngles = new Vector3(0, 0, -90);
                    break;

            }
            yield return new WaitForSeconds(1f);
           
            direction = lastDirection;
           
            yield return new WaitForSeconds(0.3f);
            direction = 0;
            yield return new WaitForSeconds(1);





        }
       
    }

    

    public int UniqueRandomInt(int min, int max)
    {
        int val = UnityEngine.Random.Range(min, max);
        while (lastDirection == val)
        {
            val = UnityEngine.Random.Range(min, max);
        }
        lastDirection = val;
        return val;
    }
    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {

            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {

            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {

                Result(1,0.ToString());
            }

            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {

                Result(2,1.ToString());
            }

            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {

                Result(3,2.ToString());
            }

            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {

                Result(4,3.ToString());
            }
        }
    }
    float z;
    void Result(int value,string trigger)
    {
       
        anim.SetTrigger("Pose_"+trigger);
        if (direction == value)
        {
           
            glow.transform.DOScale(new Vector3(10, 10, 10), 0.35f).OnComplete(() => {
                glow.transform.DOScale(Vector3.zero, 0f);

            }).SetEase(Ease.OutElastic);
            DOTween.Kill(uid);
            sequence = null;
            cloneArrow.transform.DOLocalMove(new Vector3(0,3,0), 0.5f).OnComplete(() =>
            Destroy(cloneArrow.gameObject)
            );
            box.color = Color.green;
            SpriteRenderer clonePose= Instantiate(poses, posesParent);
            clonePose.transform.localPosition = new Vector3(0, 0, z);
            clonePose.transform.localEulerAngles = new Vector3(0, 0, (UnityEngine.Random.Range(-30,30)));
               z -= 0.25f;
            clonePose.sprite = sprite[direction-1];
            amount++;
            if (amount>5)
            {
                run = false;
                confetti.gameObject.SetActive(true);
                Invoke("RestartScene", 3f);
                

            }
        }
        else
        {
            box.color = Color.red;
        }
    }
    void RestartScene()
    {
        Restart.RestartButton();
    }
}
