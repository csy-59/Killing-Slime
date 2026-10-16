using Defines;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackSO", menuName = "Scriptable Objects/AttackSO")]
public class AttackSO : Data
{
    // 기본 정보
    public float AttackRange;
    [Min(0)] public int CoolTimeTick;

    // 공격 시간
    [Min(0)] public int StartUpTick;
    [Min(0)] public int AttackTick;
    [Min(0)] public int RecoveryTick;
    public int TotalAttackTick => StartUpTick + AttackTick + RecoveryTick;

    public List<TimedAttackEvent> TimedEvent;
    public List<AttackEventSO> OnHitEvents;
    public List<AttackEventSO> OnCompletedEvents;
}
