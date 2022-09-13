using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int handleId;
    public static DragObj handleObj;
    public static int bodyId;
    
    public int handle;
    private float split;
    public Body[] body;
    private void Start()
    {
        split = Screen.width / 3;
    }
    private void Update()
    {
        handle = handleId;
        float mosPosX = Input.mousePosition.x;
        if (0<mosPosX&&mosPosX<split)
        {
            body[0].turn = true;
            body[1].turn = false;
            body[2].turn = false;
        }
        else if(split < mosPosX && mosPosX < 2*split)
        {
            body[0].turn = false;
            body[1].turn = true;
            body[2].turn = false;
        }
        else
        {
            body[0].turn = false;
            body[1].turn = false;
            body[2].turn = true;
        }
    }
}
