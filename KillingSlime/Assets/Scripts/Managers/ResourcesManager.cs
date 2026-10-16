using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourcesManager : ManagerBase
{

    private Dictionary<string, object> _cache;

    public void Initialize()
    {
        _cache = new Dictionary<string, object>();
    }

    public T LoadData<T>(string dataRoute) where T :UnityEngine.Object
    {
        if(GetFromCache(dataRoute, out object obj))
        {
            return (T)obj;
        }

        T r = Resources.Load<T>(dataRoute);
        if(r == null)
        {
            Debug.LogError($"[ResourcesManager] 해당 루트의 데이터 없음 {dataRoute}");
            return null;
        }

        AddToCache(dataRoute, r);

        return r;
    }

    public T[] LoadAllData<T>(string dataRoute) where T : UnityEngine.Object
    {
        string cacheKey = $"ALL:{typeof(T).FullName}:{dataRoute}";

        if (GetFromCache(cacheKey, out object cached))
        {
            return (T[])cached;
        }

        T[] result = Resources.LoadAll<T>(dataRoute);

        if (result.Length == 0)
        {
            Debug.LogWarning(
                $"[ResourcesManager] 해당 경로에 데이터 없음: {dataRoute}");
        }

        AddToCache(cacheKey, result);

        return result;
    }

    private void AddToCache(string route, in object obj)
    {
        if(_cache.TryAdd(route, obj) == false)
        {
            Debug.Log("[ResourcesManager] 같은 루트의 데이터 캐싱 중");
        }
    }

    private bool GetFromCache(string route, out object obj)
    {
        return _cache.TryGetValue(route, out obj);
    }
}
