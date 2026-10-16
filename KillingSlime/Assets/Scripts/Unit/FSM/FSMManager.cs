using UnityEngine;

public class FSMManager
{
    private FSMState _currentFSMState;
    public FSMState CurrentFSMState;

    public void ChangeState(FSMState nextState, bool isReenter = false)
    {
        if(nextState == null || 
            (isReenter == false && nextState == CurrentFSMState))
        {
            return;
        }

        CurrentFSMState?.Exit();

        _currentFSMState = nextState;
        _currentFSMState.Enter();
    }

    public void Tick(float deltaTime)
    {
        _currentFSMState?.Tick(deltaTime);
    }
}
