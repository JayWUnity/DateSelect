using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class DateControl : MonoBehaviour
{
    public static DateControl Instance = null;
    public string SelectDate;
    private Text YearAndMonthText;

    private Text[] TextArray;

    private int year;
    private int month;

    void Awake()
    {
        Instance = this;
        TextArray = transform.Find("Date").GetComponentsInChildren<Text>();
        YearAndMonthText = transform.Find("YearAndMonth").GetComponent<Text>();
    }

    

    // Use this for initialization
    void Start()
    {
        DateTime now=DateTime.Today;
        year = now.Year;
        month = now.Month;
        ShowDate(now.Year,now.Month);
    }

    public void OnClickHandle(string day)
    {
        SelectDate = year + "年" + month + "月" + day + "日";
        Debug.Log(SelectDate);
        //TODO
    }

    public void Last()
    {
        month--;
        if (month == 0)
        {
            year--;
            month = 12;
        }
        ShowDate(year,month);
    }

    public void Next()
    {
        month++;
        if (month == 13)
        {
            year++;
            month = 1;
        }
        ShowDate(year, month);
    }

    void ShowDate(int year,int month)
    {
        foreach (Text item in TextArray)
        {
            item.text = "";
        }
        YearAndMonthText.text = year + "年" + month + "月";
        int week = GetFirstDayWeekInMonth(year.ToString(), month.ToString());
       int count= DateTime.DaysInMonth(year, month);
       for (int i = 1; i < count; i++)
       {
           TextArray[i + week-1].text = i.ToString();
       }
    }


    //获取本月第一天是周几
    int GetFirstDayWeekInMonth(string year,string month)
    {
        string date = year + "-" + month + "-" + "01";
        DateTime dt= Convert.ToDateTime(date);
         return Convert.ToInt32(dt.DayOfWeek);
    }


}