using BuffAndDebuff;
using UnityEngine;

public abstract class StatusEffectBase
{
    public StatusEffectType Type { get; }
    public float Value { get; }
    public int Duration { get; }

    public StatusEffectBase(
        StatusEffectType type,
        float value,
        int duration)
    {
        Type = type;
        Value = value;
        Duration = duration;
    }

    public abstract void OnApply(UnitStatusBase unit);
    public virtual void OnUpdate(UnitStatusBase unit) { }
    public abstract void OnRemove(UnitStatusBase unit);
}