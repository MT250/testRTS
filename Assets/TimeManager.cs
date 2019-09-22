using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float hours = 0, minutes = 0;
    [SerializeField]
    private Text timeDisplay;

    private void Start()
    {
        timeDisplay = GameObject.Find("TimeText").GetComponent<Text>();   
    }

    private void Update()
    {
        InGameTimeCount();
        UpdateUI();
    }

    private void UpdateUI()
    {
        string hrs, min;

        if (hours < 10) { hrs = "0" + hours; }
            else hrs = hours.ToString();
        if (minutes < 10) { min = "0" + Math.Truncate(minutes); }
            else min = Math.Truncate(minutes).ToString();

        timeDisplay.text = hrs + ":" + min;
    }

    private void InGameTimeCount()
    {
        minutes += Time.deltaTime;

        if (minutes >= 60)
        {
            minutes = 0; hours++;
            if (hours >= 24) hours = 0;
        }
    }
}
