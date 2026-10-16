using System.Collections.Generic;
using UnitDefines;
using UnityEngine;

/// <summary>
/// 각 유닛(플레이어, 에너미)에 대한 상태 및 현재 상태
/// </summary>
public abstract class UnitStatusBase
{
    public UnitState CurrentState { get; set; }
    public int CurrentHP { get; set; }
    public int Speed { get; set; }
    public int Defense { get; set; }
    public int Damage { get; set; }
    public float MoveSpeed { get; set; }
}
