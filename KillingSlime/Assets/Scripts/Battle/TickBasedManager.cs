using UnityEngine;

public abstract class TickBasedManager
{
    private readonly float EVALUATION_TICK;
    private float _elapsedTick;

    public TickBasedManager(float tick)
    {
        if(tick <= 0)
        {
            Debug.LogError($"[{GetType().Name}] 기준 틱 값 이상 {tick}");
            return;
        }

        EVALUATION_TICK = tick;
    }

    // 현재 틱에서 평가를 몇번 해야하는지
    public int GetEvaluationCount(float tickDelta)
    {
        _elapsedTick += tickDelta;

        int result = Mathf.FloorToInt(
            _elapsedTick / EVALUATION_TICK);

        _elapsedTick -= result * EVALUATION_TICK;

        return result;
    }

    // 정해진 틱마다 실행
    public abstract void Evaluate();
}
