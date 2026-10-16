using System;
using UnityEngine;

public abstract class TickBasedManager
{
    protected readonly int EVALUATION_TICK;

    private int _elapsedTick;

    public TickBasedManager(int tick)
    {
        if(tick <= 0)
        {
            Debug.LogError($"[{GetType().Name}] 기준 틱 값 이상 {tick}");
            throw new ArgumentOutOfRangeException(nameof(tick));
        }

        EVALUATION_TICK = tick;
        _elapsedTick = 0;
    }

    // 현재 틱에서 평가를 몇번 해야하는지
    public int GetEvaluationCount(int deltaTick)
    {
        _elapsedTick += deltaTick;

        int result = _elapsedTick / EVALUATION_TICK; // 자동으로 소수점 버려짐
        _elapsedTick %= EVALUATION_TICK; // 남은 시간 누적

        return result;
    }

    // 정해진 틱마다 실행
    public abstract void Evaluate();
}
