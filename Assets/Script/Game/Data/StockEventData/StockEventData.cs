using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StockEventData
{
    private StockEventType _eventType;
    private Action<StockEventType> _callback;

    public void Init(StockEventType eventType)
    {
        this._eventType = eventType;
    }


    public void StartEvent(float duration, Action<StockEventType> callback)
    {
        _callback = callback;
        SetData();
        GameRoot.Instance.WaitTimeAndCallback(duration, EndEvent);
    }

    public void EndEvent()
    {
        _callback.Invoke(_eventType);
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
