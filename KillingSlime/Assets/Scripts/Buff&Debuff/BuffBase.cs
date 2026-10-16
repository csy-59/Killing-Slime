using BuffAndDebuff;
using UnityEngine;

public abstract class BuffBase
{
    public BuffType Type { get; private set; }
    public float Value { get; private set; }

    public BuffBase(BuffType type, float value)
    {
        Type = type;
        Value = value;
    }

    public abstract UnitBase Buffed(UnitBase unit);
}

public abstract class DebuffBase
{
    public DebuffType Type;
    public float Value;

    public DebuffBase(DebuffType type, float value)
    {
        Type = type;
        Value = value;
    }

    public abstract UnitBase Debuffed(UnitBase unit);
}
