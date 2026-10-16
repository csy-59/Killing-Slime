using Defines;
using EnemyDefine;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DataSet<T> : IDataSet where T : Data
{
    private Dictionary<int, T> _dataDict;
    public T GetData(int id) => _dataDict.ContainsKey(id) ? _dataDict[id] : null;

    public DataSet(string route)
    {
        SetData(route);
    }

    public virtual void SetData(string route)
    {
        _dataDict = new Dictionary<int, T>();
        _dataDict.Clear();

        var datas = Managers.Instance.GetManager<ResourcesManager>().LoadAllData<T>(route);

        foreach (var data in datas)
        {
            if (data == null)
                continue;

            if (!_dataDict.TryAdd(data.ID, data))
            {
                Debug.LogError(
                    $"[DataSet] 중복 ID: {data.ID}, Type: {typeof(T).Name}"
                );
            }
        }
    }
}
