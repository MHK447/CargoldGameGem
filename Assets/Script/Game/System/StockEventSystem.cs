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
        //TODO: 스테이지 선택해서 각 시작 시점을 적용하도록 수정
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
        eventData.StartEvent(CallBack);
    }


    private StockEventType GetRandomEvent()
    {
        Array values = Enum.GetValues(typeof(StockEventType));
        int randomIndex = UnityEngine.Random.Range(0, values.Length);
        return (StockEventType)values.GetValue(randomIndex);
    }


    public void CallBack(StockEventType eventtype, EventInfoData eventInfoData)
    {
        Debug.Log($"HighCl_{Time.time}:\nCallback: {eventtype}, EventInfoData: {eventInfoData}");
    }
}
