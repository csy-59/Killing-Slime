using Effector;
using System;
using UnityEngine;

public abstract class StatusEffectBase
{
    public abstract bool TryApply(IEffectable unit);
    public virtual void OnUpdate(IEffectable unit) { }
    public abstract void OnRemove(IEffectable unit);
}