using BanpoFri;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StockEventType
{
    A,
    B,
    C,
}

public class StockEventSystem : MonoBehaviour
{
    public float event1StartTime = 0;
    public float event2StartTime = 2;
    public float event3StartTime = 4;

    void Start()
    {
        GameRoot.Instance.WaitTimeAndCallback(event1StartTime, StartEvent);
        GameRoot.Instance.WaitTimeAndCallback(event2StartTime, StartEvent);
        GameRoot.Instance.WaitTimeAndCallback(event3StartTime, StartEvent);
    }

    private void StartEvent()
    {
        StockEventType stockEventType = GetRandomEvent();
        Debug.Log($"HighCl_{Time.time}:\nEntry StartEvent: {stockEventType}");

        StockEventData eventData = new StockEventData();
        eventData.Init(stockEventType);

        //TODO: 테이블 키 받아오는거 임시
        var duration = 3f;
        //var duration = Tables.Instance.GetTable<Define>().GetData("Duration").value;
        eventData.StartEvent(duration, CallBack);

    }


    private StockEventType GetRandomEvent()
    {
        Array values = Enum.GetValues(typeof(StockEventType));
        int randomIndex = UnityEngine.Random.Range(0, values.Length);
        return (StockEventType)values.GetValue(randomIndex);
    }


    public void CallBack(StockEventType eventtype)
    {
        Debug.Log($"HighCl_{Time.time}:\nCallback: {eventtype}");
    }
}
