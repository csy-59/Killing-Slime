using System.Reflection.Metadata.Ecma335;
using UnityEngine;

public class FSMManager
{
    private FSMState _prevState;
    public FSMState PrevState;

    private FSMState _currentFSMState;
    public FSMState CurrentFSMState;

    public void ChangeState(FSMState nextState, bool isReenter = false)
    {
        if(nextState == null || 
            (isReenter == false && nextState == CurrentFSMState))
        {
            return;
        }

        if(isReenter)
        {
            CurrentFSMState?.Reenter();
            return;
        }

        CurrentFSMState?.Exit();
        _prevState = CurrentFSMState;

        _currentFSMState = nextState;
        _currentFSMState.Enter();
    }

    public void Tick(float deltaTime)
    {
        _currentFSMState?.Tick(deltaTime);
    }
}
