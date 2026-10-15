using System;
using UnityEngine;

namespace EnemyDefine
{
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
        public int HP;
        public int Damage;
        public float MoveSpeed;
        public float AttackCoolTime;
    }

}
