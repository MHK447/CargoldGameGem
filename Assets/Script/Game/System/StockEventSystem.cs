using BanpoFri;
using DefaultSetting.Utility;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StockEventSystem
{
    public static int Temp_SpeedMin = 50;
    public static int Temp_DownRate = 50;

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
        return eventInfo.DataList.Where(e => e.stage_id == 0 || e.stage_id == currentStage).ToList();
    }

    public void StageEventSetting(int stageID)
    {
        StageInfoData stageInfo = Tables.Instance.GetTable<StageInfo>().GetData(stageID);
        stageInfo.event_time.ForEach(e => GameRoot.Instance.WaitTimeAndCallback(e / 100, StartEvent));
    }

    private void StartEvent()
    {
        EventInfoData stockEventInfo = GetRandomEvent();
        //Debug.Log($"HighCl_{Time.time}: Entry\n stockEventID: {stockEventInfo.event_id}");

        StockEventData stockEventData = new StockEventData();
        stockEventData.Init(stockEventInfo);
        stockEventData.StartEvent(CallBack);
    }

    private EventInfoData GetRandomEvent()
    {
        float[] eventWeights = new float[_cashingCurrentStageEventList.Count];
        for (int i = 0; i < _cashingCurrentStageEventList.Count; i++)
            eventWeights[i] = _cashingCurrentStageEventList[i].event_weight; //TODO: 추후 가중치 변수로 변경
        int randomIdx = Extension.RandomWeightedIndex(eventWeights);

        EventInfoData randomEventInfoData = _cashingCurrentStageEventList[randomIdx];
        return randomEventInfoData;
    }

    public void CallBack(EventInfoData eventInfoData)
    {
        Debug.Log($"HighCl_{Time.time}: Callback\nEventInfoData: {eventInfoData.event_id}");
    }
}
