using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MoneyCollider : MonoBehaviour
{
    public Manage manage;
    public Transform trashPoint;
    public Transform holderPoint;
    Move move;
    Vector3 startPos;
    Vector3 startRot;
    public Text moneyText;
    public int money;
    public GameObject confetti;
    public Animator TrashAnim;
    private void Awake()
    {
        startPos = transform.position;
        startRot = transform.rotation.eulerAngles;
    }
    private void Start()
    {
        move = transform.GetComponent<Move>();
       
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag=="Trash")
        {

            Move(trashPoint,10);
            TrashAnim.SetTrigger("MoneyShredStart");


            if (manage.random==1)
            {
                money -= 10;
                moneyText.text = money.ToString();
                moneyText.transform.DOScale(new Vector3(1, 1, 1), 1f).OnComplete(() => {
                    moneyText.transform.DOScale(Vector3.zero, 0.5f);

                }).SetEase(Ease.OutElastic);
            }
            else
            {
                Debug.Log("Yeah");
            }
        }
        if (other.tag=="Holder")
        {
            Move(holderPoint,6);
            if (manage.random == 1)
            {
                Debug.Log("Yeah");

                money += 10;
                moneyText.text = money.ToString();
                confetti.SetActive(true);
                moneyText.transform.DOScale(new Vector3(1, 1, 1), 1f).OnComplete(() => {
                    moneyText.transform.DOScale(Vector3.zero, 0.5f);
                    confetti.SetActive(false);
                }).SetEase(Ease.OutElastic);
            }
            else
            {
                money -= 10;
                moneyText.text = money.ToString();
                moneyText.transform.DOScale(new Vector3(1, 1, 1), 1f).OnComplete(() => {
                    moneyText.transform.DOScale(Vector3.zero, 0.5f);
                   
                }).SetEase(Ease.OutElastic);
            }
        }
    }
   void Move(Transform movePoint,int value)
    {
        transform.GetComponent<BoxCollider>().enabled = false;
        move.run = false;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.DOMove(movePoint.position, 0.5f);
        transform.DORotate(movePoint.rotation.eulerAngles, 0.5f).OnComplete(() =>
         transform.DOMoveZ(transform.position.z + value, 1f).OnComplete(() => {
             transform.position = startPos;
             transform.eulerAngles = startRot;
             manage.RandomMoney();
             move.StartMove();
            
         }));
    }

}
