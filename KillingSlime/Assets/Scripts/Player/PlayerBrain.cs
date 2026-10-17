using UnitDefines;
using UnityEngine;

public class PlayerBrain : UnitBrain
{

    public PlayerBrain(PlayerController controller) : 
        base(controller)
    {
    }

    protected override void ResetFSMStates()
    {
        base.ResetFSMStates();

        _fsmList.Add(new PlayerIdle(_fsmManager, _controller as PlayerController));
        _fsmList.Add(new PlayerChase(_fsmManager, _controller as PlayerController));
        _fsmList.Add(new PlayerAttack(_fsmManager, _controller as PlayerController));
        _fsmList.Add(new PlayerKnockBack(_fsmManager, _controller as PlayerController));
        _fsmList.Add(new PlayerDeath(_fsmManager, _controller as PlayerController));
    }

    protected override void FSMTick(int deltaTick)
    {
        base.FSMTick(deltaTick);
    }
}
