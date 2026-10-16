using UnityEngine;

/// <summary>
/// 계속 하면서 수정할 예정
/// </summary>
[CreateAssetMenu(fileName = "GameSettingSO", menuName = "Scriptable Objects/GameSettingSO")]
public class GameSettingSO : ScriptableObject
{
    public double FixedFrame = 0.05d;
    public int MaxTicksPerFrame = 5;
    public int MaxDelayTick = 10;

    public int StatusEffectTick = 4;
    public int MaxEffectCount = 10;
}
