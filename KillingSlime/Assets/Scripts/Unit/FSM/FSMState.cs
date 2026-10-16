using UnityEngine;

public abstract class FSMState
{
    protected FSMManager _manager;

    public FSMState(FSMManager manager)
    {
        _manager = manager;
    }


    public virtual void Enter() { }
    public virtual void Reenter() { }
    public virtual void Tick(float deltaTime) { }
    public virtual void Exit() { }
}
