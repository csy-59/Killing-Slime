using Effector;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StatusEffectManager : TickBasedManager
{
    private class EffectSet
    {
        public IEffectable Target { get; }
        public StatusEffectBase Effect { get; }
        public int LeftTick { get; private set; }

        public EffectSet(IEffectable target, StatusEffectBase effect, int durationTick)
        {
            Target = target;
            Effect = effect;
            LeftTick = durationTick;
        }

        public bool OnApply() => Effect.TryApply(Target);
        public void OnUpdate(int deltaTick)
        {
            LeftTick -= deltaTick;
            Effect.OnUpdate(Target);
        }
        public void OnRemove()
        {
            Effect.OnRemove(Target);
        }
    }

    private List<EffectSet> _effectList;
    
    public StatusEffectManager(int tick, int maxEffectCount) : base(tick)
    {
        _effectList = new(maxEffectCount);
    }

    public void RegisterStatusEffect(IEffectable target, StatusEffectSO definition)
    {
        if (target == null || definition == null)
            return;

        if (definition.DurationTick <= 0)
        {
            Debug.Log($"[StatusEffectManager] (디)버프 값 이상. {definition.DurationTick}");
            return; 
        }

        StatusEffectBase effect = definition.CreateRuntime();

        EffectSet entry = new EffectSet(target, effect, definition.DurationTick);
        if (effect.TryApply(target) == false)
            return;
        _effectList.Add(entry);
    }

    public override void Evaluate()
    {
        for (int i = 0; i < _effectList.Count; ++i)
        {
            if (_effectList[i].Target == null ||
                _effectList[i].LeftTick <= 0)
            {
                RemoveEffect(i); --i;
                continue;
            }

            _effectList[i].OnUpdate(EVALUATION_TICK);
        }
    }

    public void ClearTarget(IEffectable unit)
    {
        for(int i = 0; i < _effectList.Count; ++i)
        {
            if (_effectList[i].Target == unit)
            {
                RemoveEffect(i);
                --i;
            }
        }
    }

    private void RemoveEffect(int index)
    {
        if(index < 0 || index >= _effectList.Count)
        {
            Debug.Log($"[StatusEffectManager] 삭제 대상 버프 인덱스 이상 {index}");
            return;
        }

        if (_effectList[index].Target != null)
        {
            _effectList[index].OnRemove();
        }

        _effectList.RemoveAt(index);
    }
}
