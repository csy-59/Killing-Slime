using System.Collections.Generic;
using UnitDefines;
using UnityEngine;

public abstract class UnitBrain
{
    protected UnitStatusBase _state;
    protected UnitView _view;


    #region FSM
    protected FSMManager _fsmManager;
    protected List<FSMState> _fsmList;
    #endregion

    public UnitBrain(UnitStatusBase state, UnitView view)
    {
        _state = state;
        _view = view;
        view.Initialize();
    }

    protected virtual void ResetFSMStates()
    {
        _fsmList = new List<FSMState>();
        _fsmManager = new FSMManager();
    }

    public virtual void Think(float deltaTime)
    {
        FSMTick(deltaTime);
    }

    protected virtual void FSMTick(float deltaTime)
    {
        _fsmManager.Tick(deltaTime);
    }
}
