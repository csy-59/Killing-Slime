using Defines;
using EnemyDefine;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Database : ManagerBase
{
    public static T GetData<T>(int id) where T : Data
        => Managers.Instance.GetManager<Database>().GetData<T>(id, true);

    private readonly Dictionary<Type, IDataSet> _database = new();

    public void Initialize()
    {
        Register<EnemyData>(Defines.Defines.EnemySODataRoute);

        Register<AttackSO>(Defines.Defines.AttackSODataRoute);
    }

    public void Register<T>(string route) where T : Data
    {
        Type type = typeof(T);

        if (_database.ContainsKey(type))
        {
            Debug.LogWarning($"[Database] 이미 등록된 타입: {type.Name}");
            return;
        }

        _database.Add(type, new DataSet<T>(route));
    }

    public DataSet<T> GetDataSet<T>() where T : Data
    {
        if (_database.TryGetValue(typeof(T), out IDataSet dataSet))
        {
            return (DataSet<T>)dataSet;
        }

        Debug.LogError($"[Database] 등록되지 않은 타입: {typeof(T).Name}");
        return null;
    }

    public T GetData<T>(int id, bool isStatic = false) where T : Data
    {
        return GetDataSet<T>()?.GetData(id);
    }
}
