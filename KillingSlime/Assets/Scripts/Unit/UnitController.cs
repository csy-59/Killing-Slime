using Effector;
using UnityEngine;

[RequireComponent(typeof(UnitView))]
public class UnitController : MonoBehaviour, IEffectable, IDamageable, IStatModifiable
{
    protected int DataID;
    protected UnitStatusBase _status;
    public UnitStatusBase Data { get => _status; }
    protected UnitBrain _brain;
    public UnitBrain Brain { get => _brain; }
    protected UnitView _view;
    public UnitView View { get => _view; }

    private bool _isEffectActive = false;
    public bool IsEffectActive => _initialized && _status.CurrentState != UnitDefines.UnitState.Death && _isEffectActive;

    protected bool _initialized = false;

    public virtual void Initialize(int id)
    {
        if (_initialized)
            return;

        SetDatas(id);

        _view.Initialize();
        _brain.Initialize();

        _initialized = true;
    }

    protected virtual void SetDatas(int id)
    {
        DataID = id;
        _status = new UnitStatusBase(id);
        _view = GetComponent<UnitView>();
        _brain = new UnitBrain(this);
    }

    public void Tick(int deltaTick)
    {
        _brain.Think(deltaTick);
    }

    public void ReceiveDamage(int amount)
    {
        if (_initialized == false)
            return;

        if (amount < 0)
            return;

        _status.CurrentHP = Mathf.Max(_status.CurrentHP - amount, 0);
        
        // todo: 여기에 사망 이벤트 발생
        if (_status.CurrentHP == 0)
            _status.CurrentState = UnitDefines.UnitState.Death;
    }

    public bool SupportStat(StatType stat)
    {
        return (int)stat >= 0 && (int)stat < (int)StatType.Count;
    }

    public int AddMultiplier(StatType stat, float mulfiplier)
    {
        if (_initialized == false)
            return -1;

        return _status.Stats.AddMultiplier(stat, mulfiplier);
    }

    public bool RemoveModifier(int handle)
    {
        if (_initialized == false)
            return false;

        return _status.Stats.RemoveModifier(handle);
    }
}
