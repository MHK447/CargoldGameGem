using BanpoFri;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StockEventData
{
    private StockEventType _eventType;
    private EventInfoData eventInfoTable;
    private Action<StockEventType, EventInfoData> _callback;

    public void Init(StockEventType eventType)
    {
        this._eventType = eventType;
        eventInfoTable = Tables.Instance.GetTable<EventInfo>().GetData(1);
    }


    public void StartEvent(Action<StockEventType, EventInfoData> callback)
    {
        _callback = callback;
        SetData();
        GameRoot.Instance.WaitTimeAndCallback(eventInfoTable.eventDurationMs / 1000, EndEvent);
    }

    public void EndEvent()
    {
        _callback.Invoke(_eventType, eventInfoTable);
    }


    private void SetData()
    {
        switch (_eventType)
        {
            case StockEventType.A:
                Debug.Log($"HighCl_{Time.time}:\nA Data Setting");
                break;
            case StockEventType.B:
                Debug.Log($"HighCl_{Time.time}:\nB Data Setting");
                break;
            case StockEventType.C:
                Debug.Log($"HighCl_{Time.time}:\nC Data Setting");
                break;
            default:
                break;
        }

    }
}
