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
    public class EnemyData
    {
        public int DataID;
        public ClassType ClassType;
        public AttackType AttackType;
        public int HP;
        public int Damage;
        public float MoveSpeed;
        public float AttackCoolTime;
    }

}
