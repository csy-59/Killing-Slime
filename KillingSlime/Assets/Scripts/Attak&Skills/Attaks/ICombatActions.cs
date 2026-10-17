using UnityEngine;

public interface ICombatActions
{
    // 피해 적용
    void DealDamage(
        UnitController attacker,
        IDamageable target,
        float damageMultiplier);

    // 상태이상 적용
    void ApplyStatusEffect(
        IEffectable target,
        StatusEffectSO effect);
}