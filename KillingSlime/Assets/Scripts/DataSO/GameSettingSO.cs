using UnityEngine;

/// <summary>
/// 계속 하면서 수정할 예정
/// </summary>
[CreateAssetMenu(fileName = "GameSettingSO", menuName = "Scriptable Objects/GameSettingSO")]
public class GameSettingSO : ScriptableObject
{
    public readonly double FixedFrame = 0.05d;
    public readonly int MaxTicksPerFrame = 5;
    public readonly int MaxDelayTick = 10;

    public readonly int StatusEffectTick;
    public readonly int MaxEffectCount;
}
