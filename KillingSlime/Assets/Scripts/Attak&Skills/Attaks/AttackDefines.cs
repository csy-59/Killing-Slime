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
    public readonly UnitController Attacker;
    public readonly IDamageable Target;
    public readonly IEffectable EffectTarget;
    public readonly ICombatActions Actions;

    public AttackContext(
        UnitController attacker,
        IDamageable target,
        IEffectable effectTarget,
        ICombatActions actions)
    {
        Attacker = attacker;
        Target = target;
        EffectTarget = effectTarget;
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
