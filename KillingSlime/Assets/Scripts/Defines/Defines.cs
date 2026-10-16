using System;
using UnityEngine;

namespace Defines
{
    public class Defines
    {
        public const string GameSettingSORoute = "Data/GameSettingSO";
        public const string EnemySODataRoute = "Data/Enemy";
        public const string AttackSODataRoute = "Data/Attack";
    }

    [Serializable]
    public abstract class FrameEvent
    {
        protected int Tick;

        public virtual void Execute() { }
        public virtual void Execute(UnitBrain brain) { }
    }

    [Serializable]
    public class Data : ScriptableObject
    {
        public int ID;
    }
}
