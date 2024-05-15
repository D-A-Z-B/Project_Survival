using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (player.MovementCompo.IsGround) {
            stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
        HandleMovementEvent();
    }

    
    private void HandleMovementEvent() {
        if (player.InputReader.xMovement.sqrMagnitude < Mathf.Epsilon) {
            player.StateMachine.ChangeState(PlayerStateEnum.Idle);
        }
        else {
            player.MovementCompo.SetMovement(player.InputReader.xMovement * player.moveSpeed);
        }
    }
}
