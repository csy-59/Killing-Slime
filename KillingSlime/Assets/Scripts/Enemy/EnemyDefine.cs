using System;
using UnityEngine;

namespace EnemyDefine
{
    public class EnemyDefines
    {
        public const string EnemyDataSetRoute = "Data/EnemyDataSetSO";
    }

    public enum EnemyState
    {
        Idle,
        Chase,
        Attack,
        Death,
    }

    public enum AttackType
    {
        Range,
        Melee,
    }

    public enum ClassType
    {
        Normal,
        Boss,
    }

    [CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyDataSO")]
    public class EnemyData : UnitData
    {
        public ClassType ClassType;
        public AttackType AttackType;
    }
}
