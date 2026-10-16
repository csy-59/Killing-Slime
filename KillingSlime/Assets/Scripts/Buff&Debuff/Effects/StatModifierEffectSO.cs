using Effector;
using UnityEngine;

[CreateAssetMenu(fileName = "StatModifierEffectSO", menuName = "Scriptable Objects/StatModifierEffectSO")]
public class StatModifierEffectSO : StatusEffectSO
{
    public StatType Stat;
    public float Multiplier = 1f;

    public override StatusEffectBase CreateRuntime()
    {
        return new StatModifierEffect(Stat, Multiplier);
    }
}
