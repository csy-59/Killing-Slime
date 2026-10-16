using System.Collections.Generic;
using UnityEngine;
using EnemyDefine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyDataSet : ScriptableObject
{
    public List<EnemyData> DataSet;
    private Dictionary<int, EnemyData> _dataDict;
    public EnemyData GetData(int id) => _dataDict.ContainsKey(id) ? _dataDict[id] : null;

    public void SetData()
    {
        foreach(var e in DataSet)
        {
            if (_dataDict.TryAdd(e.DataID, e) == false)
            {
                Debug.Log($"[EnemyDataSet] 중복된 ID의 EnemyData 추가 ({e.DataID})");
            }
        }
    }

}
