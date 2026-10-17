using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager: MonoBehaviour, ManagerBase
{
    private bool _isInitialized = false;

    private double SecondPerTick => Managers.Instance.GameSetting.FixedFrame;
    private int MaxTicksPerFrame => Managers.Instance.GameSetting.MaxTicksPerFrame;

    private double _startTime;
    private long _tickCount;
    public long CurrentTick { get { return _tickCount; } }
    private long _delayedTick;

    private List<TickBasedManager> _tickBasedManagers = new();

    public void Initialize()
    {
        if (_isInitialized)
            return;

        _isInitialized = true;

        _startTime = Time.timeAsDouble;
        gameObject.SetActive(true);
        AddTickBasedManager();
    }

    private void AddTickBasedManager()
    {
        try
        {
            _tickBasedManagers.Add(
                new StatusEffectManager(
                    Managers.Instance.GameSetting.StatusEffectTick,
                    Managers.Instance.GameSetting.MaxEffectCount));

            _tickBasedManagers.Add(
                new BattleManager(
                    Managers.Instance.GameSetting.BattleTick,
                    Managers.Instance.GameSetting.MaxEnemyCount,
                    Managers.Instance.GameSetting.EnemyGroupCount));
        }
        catch (ArgumentOutOfRangeException e)
        {
            _isInitialized = false;
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (_isInitialized == false)
            return;

        double elapsed = Time.timeAsDouble - _startTime;

        long targetTick = (long)Math.Floor(
            elapsed / SecondPerTick);

        long pendingTick = Math.Max(0L, targetTick - _tickCount);

        int processCount = (int)Math.Min(
            pendingTick, MaxTicksPerFrame);

        for (int i = 0; i < processCount; ++i)
        {
            ++_tickCount;

            foreach (var manager in _tickBasedManagers)
            {
                int count = manager.GetEvaluationCount(1);

                for (int j = 0; j < count; ++j)
                {
                    manager.Evaluate();
                }
            }
        }

        _delayedTick = Math.Max(0L, targetTick - _tickCount);
    }

}
