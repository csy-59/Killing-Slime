using Defines;
using System;
using UnityEngine;

public enum AttackTrigger
{
    AtFrame,
    OnHit,
}

public enum EffectTarget
{
    Self,
    Target,
    Ally, // 나랑 나의 동료
}

public readonly struct AttackContext
{
    public readonly UnitStatusBase Attacker;
    public readonly UnitStatusBase Target;
    public readonly ICombatActions Actions;

    public AttackContext(
        UnitStatusBase attacker,
        UnitStatusBase target,
        ICombatActions actions)
    {
        Attacker = attacker;
        Target = target;
        Actions = actions;
    }
}

public abstract class AttackEventSO :ScriptableObject
{
    public abstract void Execute(AttackContext constext);
}

[Serializable]
public class TimedAttackEvent
{
    [Min(0)] public int Tick;
    public AttackEventSO Event;
}
