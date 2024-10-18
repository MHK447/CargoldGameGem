using BanpoFri;
using DefaultSetting.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum StockEventType
{
    A,
    B,
    C,
}

public class StockEventSystem
{
    public void Init()
    {
        Debug.Log($"HighCl_{Time.time}:\nStock Event Init");
       
        int temp_currentStage = 1; //TODO: 추후 스테이지 입장 시 받는것으로 수정
        StageEventSetting(temp_currentStage);
    }

    public void StageEventSetting(int stageID)
    {
        StageInfoData eventInfo = Tables.Instance.GetTable<StageInfo>().GetData(stageID);
        eventInfo.event_time.ForEach(e => GameRoot.Instance.WaitTimeAndCallback(e / 1000f, StartEvent));
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
