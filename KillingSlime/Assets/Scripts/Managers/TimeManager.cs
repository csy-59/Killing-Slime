using System.Collections.Generic;
using UnityEngine;

public class TimeManager: MonoBehaviour, ManagerBase
{
    private bool _isInitialized = false;
    private static float _elapsedGameTime = 0f;
    public static float ElapsedGameTime { get { return _elapsedGameTime; } }

    private List<TickBasedManager> _tickBasedManagers = new();

    public void Initialize()
    {
        if (_isInitialized)
            return;

        _isInitialized = true;

        AddTickBasedManager();
    }

    private void AddTickBasedManager()
    {
        _tickBasedManagers.Add(
            new StatusEffectManager(
                Managers.Instance.GameSetting.StatusEffectTick,
                Managers.Instance.GameSetting.MaxEffectCount));
    }

    private void Update()
    {
        _elapsedGameTime += Time.deltaTime;

        foreach(var m in _tickBasedManagers)
        {
            int count = m.GetEvaluationCount(Time.deltaTime);
            for(int i = 0; i < count; ++i)
            {
                m.Evaluate();
            }
        }
    }

}
