using UnityEngine;

namespace BuffAndDebuff
{
    public enum BuffType
    {
        SpeedBoost, // 이속 버프
        AttackSpeedBoost, // 공격 속도 버프
        AttackPowerBoost, // 공격력 버프
        
    }

    public enum DebuffType
    {
        Stun, // 기절
        DOT, // 도트 데미지
        Slow, // 이속 감소
        AttackPowerReduction, // 공격력 감소
        AttackSpeedReduction, // 공속 감소
    }
}