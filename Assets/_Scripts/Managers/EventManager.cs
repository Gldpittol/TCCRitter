using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventManager : MonoBehaviour
{
    public bool logEvents;
    private Dictionary<string, UnityEvent<object>> _eventDictionary;
    private static EventManager _instance;
    public static EventManager Instance
    {
        get
        {
            if(!_instance)
            {
                _instance = FindObjectOfType(typeof(EventManager)) as EventManager;

                if(!_instance)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    _instance.Init();
                }
            }

            return _instance;
        }
    }

    void Init()
    {
        if(_eventDictionary == null)
        {
            _eventDictionary = new Dictionary<string, UnityEvent<object>>();
        }
    }

    public static void StartListening(string eventName, UnityAction<object> listener)
    {
        if(Instance._eventDictionary.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent<object>();
            thisEvent.AddListener(listener);
            Instance._eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction<object> listener)
    {
        if(_instance == null)
        {
            return;
        }

        if(Instance._eventDictionary.TryGetValue(eventName, out var thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName, object obj = null)
    {
        if(Instance._eventDictionary.TryGetValue(eventName, out var thisEvent))
        {
            if(Instance.logEvents)
            {
                Debug.Log("#Event# TriggerEvent: " + eventName);
            }

            thisEvent?.Invoke(obj);
        }
    }
}
