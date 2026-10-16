using System;
using UnityEngine;

/// <summary>
/// 에너미, 플레이어 스텟 데이터 기반(저장 및 접근, 실제 데이터 아님)
/// </summary>
[Serializable]
public class UnitData
{
    public int DataID;
    public int HP;
    public int Defense;
    public int Damage;
    public float MoveSpeed;
}
