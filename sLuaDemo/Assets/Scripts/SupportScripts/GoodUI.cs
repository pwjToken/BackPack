using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using SLua;
using System;

public class GoodUI : MonoBehaviour,IPointerEnterHandler,IBeginDragHandler,IEndDragHandler,IPointerExitHandler,IDragHandler {


    private CanvasGroup GoodCG;
    private Transform canvas;
    void Awake()
    {
        canvas = GameObject.Find("Canvas").transform;
        GoodCG =GetComponent<CanvasGroup>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag == "Good")
        {
            //print("鼠标进入");
            //普通函数与lua交互
            //string str = (string)LuaSvr.mainState.getFunction("OnPointEnter").call(transform);
        }
        LuaSvr.mainState.getFunction("OnPointEnter").call(transform);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LuaSvr.mainState.getFunction("OnPointExit").call(transform);
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (transform.tag == "item")
            {
				Transform prepreParent =transform.parent;
                GoodCG.blocksRaycasts = false;
                transform.parent = canvas;
                LuaSvr.mainState.getFunction("OnBeginDrag").call(transform,prepreParent);

            }
            
        }
        //transform.childCount==0
        //gameObject.transform.SetParent();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerEnter);
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (eventData.pointerEnter == null)
            {
                //参数一为结束拖拽物体   eventData.pointerEnter.transform为结束物体
                LuaSvr.mainState.getFunction("OnEndDrag").call(transform, null);
            }
            else
            {
                //print(eventData.pointerEnter);
                LuaSvr.mainState.getFunction("OnEndDrag").call(transform, eventData.pointerEnter.transform);
            }
        }
        GoodCG.blocksRaycasts = true;
        

    }

    public void OnDrag(PointerEventData eventData)
    {
        LuaSvr.mainState.getFunction("OnDrag").call();
    }
}
