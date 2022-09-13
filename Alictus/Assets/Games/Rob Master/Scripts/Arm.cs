using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Arm : MonoBehaviour
{
    public Text loseText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Laser")
        {


            loseText.transform.DOScale(new Vector3(1, 1, 1), 1f).OnComplete(() => {
                loseText.transform.DOScale(Vector3.zero, 0.5f);

            }).SetEase(Ease.OutElastic);
            Invoke("RestartScene",2f);
           
        }
    }
    void RestartScene()
    {
        Restart.RestartButton();
    }
}
