using Effector;
using UnityEngine;

public interface IStatModifiable : IEffectable
{
    public bool SupportStat(StatType stat);
    public int AddMultiplier(StatType stat, float mulfiplier);
    public bool RemoveModifier(int handle);
}
