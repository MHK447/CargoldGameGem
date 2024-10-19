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

    private int _currentStage = 1;
    private int _eventOrderIdx = 0;

    public void Init()
    {
        if (_isInit)
            return;

        _isInit = true;

        Debug.Log($"HighCl_{Time.time}:\nStock Event Init");

        _cashingCurrentStageEventList = CashingCurrentStageEventData();
        StageEventSetting(_currentStage);
    }

    private List<EventInfoData> CashingCurrentStageEventData()
    {
        EventInfo eventInfo = Tables.Instance.GetTable<EventInfo>();
        return eventInfo.DataList.Where(e => e.stage_id == 0 || e.stage_id == _currentStage).ToList();
    }

    public void StageEventSetting(int stageID)
    {
        _currentStage = stageID;
        _eventOrderIdx = 0;

        StageInfoData stageInfo = Tables.Instance.GetTable<StageInfo>().GetData(_currentStage);
        stageInfo.event_time.ForEach(e => GameRoot.Instance.WaitTimeAndCallback(e / 100, StartEvent));
    }

    private void StartEvent()
    {
        EventInfoData stockEventInfo = GetRandomEvent();
        //Debug.Log($"HighCl_{Time.time}: Entry\n stockEventID: {stockEventInfo.event_id}");

        StockEventData stockEventData = new StockEventData();
        stockEventData.Init(stockEventInfo);
        stockEventData.StartEvent(CallBack);

        _eventOrderIdx++;
    }

    private EventInfoData GetRandomEvent()
    {
        int event_goodbad = Tables.Instance.GetTable<StageInfo>().GetData(_currentStage).event_goodbad[_eventOrderIdx];
        List<EventInfoData> canEventList = _cashingCurrentStageEventList.Where(e =>
        {
            switch (event_goodbad)
            {
                case 0:
                    if (e.good_event_yn == 0)
                        return true;
                    else
                        return false;
                case 1:
                    if (e.good_event_yn == 1)
                        return true;
                    else
                        return false;
                case 2:
                    return true;
                default:
                    Debug.LogError("good_event_yn 잘못된 값 예외");
                    return false;
            }
        }).ToList();

        float[] eventWeights = new float[canEventList.Count];
        for (int i = 0; i < canEventList.Count; i++)
            eventWeights[i] = canEventList[i].event_weight; //TODO: 추후 가중치 변수로 변경
        int randomIdx = Extension.RandomWeightedIndex(eventWeights);
        EventInfoData randomEventInfoData = canEventList[randomIdx];
        return randomEventInfoData;
    }

    public void CallBack(EventInfoData eventInfoData)
    {
        Debug.Log($"HighCl_{Time.time}: Callback\nEventInfoData: {eventInfoData.event_id}");
    }
}
