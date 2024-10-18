using BanpoFri;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StockEventSystem
{
    private bool _isInit = false;
    private List<EventInfoData> _cashingCurrentStageEventList;
    
    int currentStage = 1;

    public void Init()
    {
        if (_isInit)
            return;
        _isInit = true;

        Debug.Log($"HighCl_{Time.time}:\nStock Event Init");

        StageEventSetting(currentStage);
    }

    public void StageEventSetting(int stageID)
    {
        StageInfoData eventInfo = Tables.Instance.GetTable<StageInfo>().GetData(stageID);
        _cashingCurrentStageEventList = CashingCurrentStageEventData();
        eventInfo.event_time.ForEach(e => GameRoot.Instance.WaitTimeAndCallback(e / 1000f, StartEvent));
    }

    private List<EventInfoData> CashingCurrentStageEventData()
    {
        EventInfo eventInfo = Tables.Instance.GetTable<EventInfo>();
        return eventInfo.DataList.Where(e => e.stageId == 0 || e.stageId == currentStage).ToList();
    }

    private void StartEvent()
    {
        int stockEventID = GetRandomEvent();
        Debug.Log($"HighCl_{Time.time}:\nEntry stockEventID: {stockEventID}");

        StockEventData eventData = new StockEventData();
        eventData.Init(stockEventID);
        eventData.StartEvent(CallBack);
    }

    private int GetRandomEvent()
    {
        int randomEventID = _cashingCurrentStageEventList[Random.Range(0, _cashingCurrentStageEventList.Count)].eventid;
        return randomEventID;
    }

    public void CallBack(int stockEventID, EventInfoData eventInfoData)
    {
        Debug.Log($"HighCl_{Time.time}:\nCallback: {stockEventID}, EventInfoData: {eventInfoData}");
    }
}
