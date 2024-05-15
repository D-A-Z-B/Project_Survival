using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.InputReader.JumpEvent += HandleJumpEvent;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (player.RigidCompo.velocity.y < 0) {
            stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }

    public override void Exit()
    {
        player.InputReader.JumpEvent -= HandleJumpEvent;
        base.Exit();
    }

    private void HandleJumpEvent() {
        if (player.MovementCompo.IsGround) return;
        stateMachine.ChangeState(PlayerStateEnum.Jump);
    }
}
