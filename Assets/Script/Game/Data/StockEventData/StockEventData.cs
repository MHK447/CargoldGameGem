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
        GameRoot.Instance.WaitTimeAndCallback(duration, EndEvent);
    }

    public void EndEvent()
    {
        _callback.Invoke(_eventType);
    }
}
