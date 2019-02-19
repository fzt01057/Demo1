using System;
using Assets.Script.Common;
using Assets.Script.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PointScript : MonoBehaviour {

    private int value;
    UIEventListener eventListener;
    GameAreaInit parent;
    public int width;
    public int height;
    public bool isVaild = true;
    Image img;
    Text text;
    bool isFlag = false;


    private void Awake()
    {
        parent = transform.GetComponentInParent<GameAreaInit>();
        img = gameObject.GetComponent<Image>();
        text = transform.GetChild(0).GetComponent<Text>();
        switch (GameController.Instance.mode)
        {
            case ModeEnum.Easy:
                value = Random.Range(0, 100) > 10 ? 0 : -1;
                break;
            case ModeEnum.Normal:
                value = Random.Range(0, 100) > 15 ? 0 : -1;
                break;
            case ModeEnum.Hard:
                value = Random.Range(0, 100) > 20 ? 0 : -1;
                break;
            default:
                value = 0;
                break;
        }
        if (value == -1)
            parent.bomb++;
        eventListener = gameObject.GetComponent<UIEventListener>();
        eventListener.PointerDown += OnDown;
        eventListener.PointerUp += OnUp;
    }

    private void OnDown(PointerEventData eventData)
    {
        if (!parent.isLive)
            return;
        parent.isPress = true;
    }

    public void OnUp(PointerEventData eventData)
    {
        if (!parent.isLive)
            return;
        if (!parent.isRunning)
            parent.isRunning = true;
        if (parent.delayTime >= 0.3)
            OnPress(eventData);
        else
            OnClick(eventData);
        parent.isPress = false;
    }

    private void OnPress(PointerEventData eventData)
    {
        if (isFlag)
        {
            img.color = Color.white;
            text.text = string.Empty;
            parent.bomb++;
            parent.num++;
        }
        else
        {
            img.color = Color.yellow;
            text.text = "旗";
            parent.bomb--;
            parent.num--;
        }
        isFlag = !isFlag;
    }

    public void OnClick(PointerEventData eventData)
    {
        if (isFlag)
            return;
        if (isVaild)
            parent.num--;
        isVaild = false;
        img.raycastTarget = false;
        img.color = Color.gray;
        text.raycastTarget = false;
        if (value == -1)
        {
            parent.isLive = false;
            isVaild = true;
            img.color = Color.red;
            text.text = "雷";
            parent.isRunning = false;
            GameController.Instance.Lost();
            return;
        }
        PointScript[] neighbour = parent.GetNeightbour(width, height);
        //可能有多个栈帧都同时检测到这个点了，然后value就被多次增加导致了value的值不等于0,所以如果该点已经检测完了就直接退出
        if (value == 0)
            for (int i = 0; i < neighbour.Length; i++)
                if (neighbour[i].value == -1)
                    value++;
        if (value == 0)
            for (int i = 0; i < neighbour.Length; i++)
                neighbour[i].OnClick(eventData);
        text.text = value == 0 ? string.Empty : value.ToString();
        if (parent.num == parent.bomb)
            GameController.Instance.Win();
    }
}
