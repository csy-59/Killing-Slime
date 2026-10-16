using Effector;
using UnityEngine;

public class StatModifierEffect : StatusEffectBase
{
    private readonly StatType _stat;
    private readonly float _multiplier;
    private int _modifierHandle;

    public StatModifierEffect(StatType stat, float multiplier)
    {
        _stat = stat;
        _multiplier = multiplier;
    }

    public override void OnApply(UnitStatusBase unit)
    {
        _modifierHandle =
            unit.Stats.AddMultiplier(_stat, _multiplier);
    }

    public override void OnRemove(UnitStatusBase unit)
    {
        unit.Stats.RemoveModifier(_modifierHandle);
    }
}
