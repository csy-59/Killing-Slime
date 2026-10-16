using UnityEngine;

[CreateAssetMenu(fileName = "StatusEffectSO", menuName = "Scriptable Objects/StatusEffectSO")]
public abstract class StatusEffectSO : ScriptableObject
{
    [SerializeField, Min(1)]
    private int _durationTick = 1;

    public int DurationTick => _durationTick;

    public abstract StatusEffectBase CreateRuntime();
}
