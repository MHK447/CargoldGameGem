using BanpoFri;
using DefaultSetting.Utility;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StockEventSystem
{
    private bool _isInit = false;
    private List<EventInfoData> _cashingCurrentStageEventList;
    
    int currentStage = 2;

    public void Init()
    {
        if (_isInit)
            return;
        _isInit = true;

        Debug.Log($"HighCl_{Time.time}:\nStock Event Init");

        _cashingCurrentStageEventList = CashingCurrentStageEventData();
        StageEventSetting(currentStage);
    }

    private List<EventInfoData> CashingCurrentStageEventData()
    {
        EventInfo eventInfo = Tables.Instance.GetTable<EventInfo>();
        return eventInfo.DataList.Where(e => e.stageId == 0 || e.stageId == currentStage).ToList();
    }

    public void StageEventSetting(int stageID)
    {
        StageInfoData stageInfo = Tables.Instance.GetTable<StageInfo>().GetData(stageID);
        stageInfo.event_time.ForEach(e => GameRoot.Instance.WaitTimeAndCallback(e / 100, StartEvent));
        stageInfo.Print();
    }

    private void StartEvent()
    {
        EventInfoData stockEventInfo = GetRandomEvent();
        Debug.Log($"HighCl_{Time.time}: Entry\n stockEventID: {stockEventInfo.eventid}");

        StockEventData stockEventData = new StockEventData();
        stockEventData.Init(stockEventInfo);
        stockEventData.StartEvent(CallBack);
    }

    private EventInfoData GetRandomEvent()
    {
        EventInfoData randomEventInfoData = _cashingCurrentStageEventList[Random.Range(0, _cashingCurrentStageEventList.Count)];
        return randomEventInfoData;
    }

    public void CallBack(EventInfoData eventInfoData)
    {
        Debug.Log($"HighCl_{Time.time}: Callback\nEventInfoData: {eventInfoData.eventid}");
    }
}
