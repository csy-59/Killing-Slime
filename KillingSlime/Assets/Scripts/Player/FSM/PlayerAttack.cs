using UnityEngine;

public class PlayerAttack : PlayerFSMState
{
    private int _remainDelay = 0;
    private bool _canAttack = false;

    public PlayerAttack(FSMManager manager, PlayerController controller) : base(manager, controller)
    {

    }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
    }
}
