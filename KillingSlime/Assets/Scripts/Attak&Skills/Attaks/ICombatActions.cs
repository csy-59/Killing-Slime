using UnityEngine;

public interface ICombatActions
{
    // 피해 적용
    void DealDamage(
        UnitStatusBase attacker,
        UnitStatusBase target,
        float damageMultiplier);

    // 상태이상 적용
    void ApplyStatusEffect(
        UnitStatusBase target,
        StatusEffectSO effect);
}