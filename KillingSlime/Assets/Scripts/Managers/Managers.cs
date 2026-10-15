using System;
using System.Collections.Generic;
using Unity.AI.Navigation.LowLevel;
using Unity.VisualScripting;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers _instance;
    public static Managers Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindAnyObjectByType<Managers>();
                if(_instance == null)
                {
                    GameObject go = new GameObject();
                    _instance = go.AddComponent<Managers>();
                }
            }

            return _instance;
        }
    }

    private Dictionary<Type, ManagerBase> _managerDict;

    public T GetManager<T>() where T : class, ManagerBase
    {
        if (_managerDict.ContainsKey(typeof(T)) == false)
            return null;

        return _managerDict[typeof(T)] as T;
    }

    private void Awake()
    {
        _managerDict = new Dictionary<Type, ManagerBase>();

        var managers = transform.GetComponentsInChildren<ManagerBase>();

        foreach(var m in managers)
        {
            RegisterManager(m);
        }

        AddManagersManually();

        foreach(var m in _managerDict)
        {
            m.Value.Initialize();
        }
    }

    private void AddManagersManually()
    {
        // 여기에는 그냥 class 추가
    }

    private void RegisterManager(ManagerBase manager)
    {
        Type t = manager.GetType();

        if(_managerDict.TryAdd(t, manager) == false)
        {
            Debug.Log($"[Managers] 이미 등록된 매니져 ({t.Name})");
        }
    }
}
