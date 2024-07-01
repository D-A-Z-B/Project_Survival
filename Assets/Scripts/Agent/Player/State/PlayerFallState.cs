using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerCanAttackState
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
        player.MovementCompo.SetMovement(player.InputReader.movement * player.moveSpeed);
    }
}
