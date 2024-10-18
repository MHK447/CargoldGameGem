using BanpoFri;
using DefaultSetting.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StockEventData
{
    private int _stockEventID;
    private EventInfoData eventInfoTable;
    private Action<int, EventInfoData> _callback;

    public void Init(int stockEventID)
    {
        this._stockEventID = stockEventID;
        eventInfoTable = Tables.Instance.GetTable<EventInfo>().GetData(stockEventID);
    }

    public void StartEvent(Action<int, EventInfoData> callback)
    {
        _callback = callback;
        SetData(true);
        GameRoot.Instance.WaitTimeAndCallback(eventInfoTable.eventDurationMs / 1000, EndEvent);
    }

    public void EndEvent()
    {
        SetData(false);
        _callback.Invoke(_stockEventID, eventInfoTable);
    }

    //TODO: Start인 경우 의도한 값 그대로 세팅하고, 끝나는 경우 -1 곱하기
    private void SetData(bool isStart)
    {
        switch (_stockEventID)
        {
            case 1:
                Debug.Log($"HighCl_{Time.time}:\nEvent1 Data Setting");
                break;
            case 2:
                Debug.Log($"HighCl_{Time.time}:\nEvent2 Data Setting");
                break;
            case 3:
                Debug.Log($"HighCl_{Time.time}:\nEvent3 Data Setting");
                break;
            default:
                break;
        }
    }
}
