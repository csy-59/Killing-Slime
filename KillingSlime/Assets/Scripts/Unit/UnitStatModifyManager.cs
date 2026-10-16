using Defines;
using Effector;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatModifyManager
{
    private struct Modifier
    {
        public StatType Stat;
        public float Multiplier;
    }

    // 중첩 버프의 경우, 특정 버프만 삭제 하기 위함
    private readonly Dictionary<int, Modifier> _modifiers = new();

    private readonly float[] _baseStats;
    private readonly double[] _multipliers;

    // 나중에 고정 데미지 추가 부분으로 확장할 수도 잇음

    private int _nextHandle = 1;

    public UnitStatModifyManager()
    {
        int count = (int)StatType.Count;

        _baseStats = new float[count];
        _multipliers = new double[count];

        for (int i = 0; i < count; ++i)
        {
            _multipliers[i] = 1.0;
        }
    }

    public float GetBase(StatType stat)
    {
        return _baseStats[(int)stat];
    }

    public void SetBase(StatType stat, float value)
    {
        _baseStats[(int)stat] = value;
    }

    public int AddMultiplier(StatType stat, float multiplier)
    {
        if (multiplier <= 0f || float.IsNaN(multiplier) ||
            float.IsInfinity(multiplier))
        {
            throw new ArgumentOutOfRangeException(nameof(multiplier));
        }

        int handle = _nextHandle++;

        _modifiers.Add(handle, new Modifier
        {
            Stat = stat,
            Multiplier = multiplier
        });

        _multipliers[(int)stat] *= multiplier;

        return handle;
    }

    public bool RemoveModifier(int handle)
    {
        if (!_modifiers.TryGetValue(handle, out Modifier modifier))
            return false;

        _multipliers[(int)modifier.Stat] /= modifier.Multiplier;

        _modifiers.Remove(handle);

        return true;
    }

    public void ClearModifiers()
    {
        _modifiers.Clear();

        for (int i = 0; i < _multipliers.Length; ++i)
        {
            _multipliers[i] = 1.0;
        }
    }

    public float GetFinal(StatType stat)
    {
        int index = (int)stat;

        return (float)(_baseStats[index] * _multipliers[index]);
    }
}