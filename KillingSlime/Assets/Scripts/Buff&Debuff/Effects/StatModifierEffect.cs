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

    public override bool TryApply(IEffectable target)
    {
        if ((target is IStatModifiable) == false ||
            (target as IStatModifiable).SupportStat(_stat))
            return false;

        _modifierHandle =
            (target as IStatModifiable).AddMultiplier(_stat, _multiplier);

        return _modifierHandle > -1;
    }

    public override void OnRemove(IEffectable target)
    {
        (target as IStatModifiable).RemoveModifier(_modifierHandle);
    }
}
