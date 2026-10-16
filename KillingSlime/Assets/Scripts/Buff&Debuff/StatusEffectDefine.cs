using UnityEngine;

namespace BuffAndDebuff
{
    // 버프와 디버프는 종류만 다를 뿐 관리 기준은 동일
    public enum StatusEffectType
    {
        SpeedBoost, // 이속 버프
        AttackSpeedBoost, // 공격 속도 버프
        AttackPowerBoost, // 공격력 버프

        Stun, // 기절
        DOT, // 도트 데미지
        Slow, // 이속 감소
        AttackPowerReduction, // 공격력 감소
        AttackSpeedReduction, // 공속 감소
    }
}