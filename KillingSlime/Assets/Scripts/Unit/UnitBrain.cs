using System.Collections.Generic;
using UnitDefines;
using UnityEngine;

public class UnitBrain
{
    protected UnitController _controller;

    protected UnitController _target;

    #region FSM
    protected FSMManager _fsmManager;
    protected List<FSMState> _fsmList;
    #endregion

    public UnitBrain(UnitController controller)
    {
        _controller = controller;
    }

    public void Initialize()
    {
        ResetFSMStates();
    }

    protected virtual void ResetFSMStates()
    {
        _fsmList = new List<FSMState>();
        _fsmManager = new FSMManager();
    }

    public virtual void Think(int deltaTick)
    {
        FSMTick(deltaTick);
    }

    protected virtual void FSMTick(int deltaTick)
    {
        _fsmManager.Tick(deltaTick);
    }

    public void SetTarget(UnitController target)
    {

    }
}
