using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class DayItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text text;

    Image image;

    private string content;

    //此按钮是否有效
    private bool IsEffective
    {
        get { content= text.text;return content != null; }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(IsEffective)
            image.color = new Color(1,1,1,1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(1, 1, 1, 0);
    }

    void Awake()
    {
        image = GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(OnClick);
        text = transform.Find("Text").GetComponent<Text>();
    }

    void OnClick()
    {
        if (IsEffective)
        {
            DateControl.Instance.OnClickHandle(content);
        }
    }


}