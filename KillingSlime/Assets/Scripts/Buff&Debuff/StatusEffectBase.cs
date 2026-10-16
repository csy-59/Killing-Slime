using Effector;
using System;
using UnityEngine;

public abstract class StatusEffectBase
{
    public abstract void OnApply(UnitStatusBase unit);
    public virtual void OnUpdate(UnitStatusBase unit) { }
    public abstract void OnRemove(UnitStatusBase unit);
}