using BuffAndDebuff;
using UnityEngine;

public abstract class StatusEffectBase
{
    public StatusEffectType Type { get; }
    public float Value { get; }
    public float Duration { get; }

    public StatusEffectBase(
        StatusEffectType type,
        float value,
        float duration)
    {
        Type = type;
        Value = value;
        Duration = duration;
    }

    public abstract void OnApply(UnitBase unit);
    public virtual void OnUpdate(UnitBase unit) { }
    public abstract void OnRemove(UnitBase unit);
}