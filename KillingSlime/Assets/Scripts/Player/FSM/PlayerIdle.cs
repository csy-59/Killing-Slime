using UnityEngine;

public class PlayerIdle : PlayerFSMState
{
    public PlayerIdle(FSMManager manager, PlayerController controller) : base(manager, controller)
    {
    }

    public override void Tick(float deltaTime)
    {
        base.Tick(deltaTime);


    }
}
