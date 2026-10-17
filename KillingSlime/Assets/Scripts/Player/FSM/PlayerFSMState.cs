using UnityEngine;

public class PlayerFSMState : FSMState
{
    protected PlayerController _controller;

    public PlayerFSMState(FSMManager manager, PlayerController controller) : base(manager)
    {
        _controller = controller;
    }
}
