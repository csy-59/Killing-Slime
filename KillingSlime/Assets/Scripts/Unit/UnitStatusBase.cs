using Effector;
using Defines;
using System.Collections.Generic;
using UnitDefines;
using UnityEngine;

/// <summary>
/// 각 유닛(플레이어, 에너미)에 대한 상태 및 현재 상태
/// </summary>
public class UnitStatusBase
{
    public UnitState CurrentState { get; set; }
    public int CurrentHP { get; set; }
    public int AttackID { get; set; }
    public int UnitDataID { get; set; }
    public float SightRange { get; private set; }

    public UnitStatModifyManager Stats { get; } = new UnitStatModifyManager();

    public UnitStatusBase(int dataID)
    {
        UnitData data = Database.GetData<UnitData>(dataID);

        AttackID = data.AttackID;
        UnitDataID = dataID;

        CurrentState = UnitState.Idle;
        CurrentHP = data.HP;

        SightRange = data.SightRange;

        Stats.SetBase(StatType.MoveSpeed, data.MoveSpeed);
        Stats.SetBase(StatType.AttackPower, data.Damage);
        Stats.SetBase(StatType.AttackSpeed, data.AttackSpeed);
        Stats.SetBase(StatType.Defense, data.Defense);
    }

    // 기존 Speed / Damage / Defense는 '기본값'으로 취급한다.
    public float Speed
    {
        get => (int)Stats.GetBase(StatType.MoveSpeed);
        set => Stats.SetBase(StatType.MoveSpeed, value);
    }

    public int Damage
    {
        get => (int)Stats.GetBase(StatType.AttackPower);
        set => Stats.SetBase(StatType.AttackPower, value);
    }

    public int Defense
    {
        get => (int)Stats.GetBase(StatType.Defense);
        set => Stats.SetBase(StatType.Defense, value);
    }

    public float BaseAttackSpeed
    {
        get => Stats.GetBase(StatType.AttackSpeed);
        set => Stats.SetBase(StatType.AttackSpeed, value);
    }

    public float FinalSpeed => Stats.GetFinal(StatType.MoveSpeed);
    public float FinalDamage => Stats.GetFinal(StatType.AttackPower);
    public float FinalDefense => Stats.GetFinal(StatType.Defense);
    public float FinalAttackSpeed => Stats.GetFinal(StatType.AttackSpeed);
}
