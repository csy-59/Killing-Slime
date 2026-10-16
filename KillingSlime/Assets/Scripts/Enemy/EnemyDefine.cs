using System;
using UnityEngine;

namespace EnemyDefine
{
    public class EnemyDefines
    {
        public const string EnemyDataSetRoute = "Data/EnemyDataSetSO";
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

    [Serializable]
    public class EnemyData : UnitData
    {
        public ClassType ClassType;
        public AttackType AttackType;
    }

}
