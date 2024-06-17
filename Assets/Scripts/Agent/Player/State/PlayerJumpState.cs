using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Jump();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (player.RigidCompo.velocity.y < 0f ) {
            stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
        else if (player.MovementCompo.IsGround) {
            stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    private void Jump() {
        player.RigidCompo.AddForce(Vector2.up * player.jumpPower, ForceMode2D.Impulse);
    }
}
