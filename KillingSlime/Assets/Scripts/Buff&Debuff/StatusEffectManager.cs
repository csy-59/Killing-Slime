using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : TickBasedManager
{
    private struct EffectSet
    {
        public UnitBase Target { get; }
        public StatusEffectBase Effect { get; }
        public float ExpireAt { get; }

        public EffectSet(UnitBase target, StatusEffectBase effect)
        {
            Target = target;
            Effect = effect;
            ExpireAt = TimeManager.ElapsedGameTime + effect.Duration;
        }

        public void OnApply() => Effect.OnApply(Target);
        public void OnUpdate() => Effect.OnUpdate(Target);
        public void OnRemove() => Effect.OnRemove(Target);
    }

    private List<EffectSet> _effectList;
    
    public StatusEffectManager(float tick, int maxEffectCount) : base(tick)
    {
        _effectList = new(maxEffectCount);
    }

    public void RegisterStatusEffect(UnitBase target, StatusEffectBase effect)
    {
        if (effect.Duration <= 0)
        {
            Debug.Log($"[StatusEffectManager] (디)버프 값 이상. {effect.Duration}");
            return; 
        }

        _effectList.Add(new EffectSet(target, effect));
        effect.OnApply(target);
    }

    public override void Evaluate()
    {
        ApplyEffect();
    }

    public void ClearTarget(UnitBase unit)
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

    private void ApplyEffect()
    {
        for(int i = 0; i < _effectList.Count; ++i)
        {
            if (_effectList[i].Target == null ||
                _effectList[i].ExpireAt <= TimeManager.ElapsedGameTime)
            {
                RemoveEffect(i); --i;
                continue;
            }

            _effectList[i].OnUpdate();
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
