using UnityEngine;

/// <summary>
/// 계속 하면서 수정할 예정
/// </summary>
[CreateAssetMenu(fileName = "GameSettingSO", menuName = "Scriptable Objects/GameSettingSO")]
public class GameSettingSO : ScriptableObject
{
    public readonly float StatusEffectTick;
    public readonly int MaxEffectCount;
}
