using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerState
{
    Vector2 movementDirection;
    public PlayerWalkState(Player player, PlayerStateMachine stateMachine, string boolName) : base(player, stateMachine, boolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Vector2 velocity = movementDirection;
        player.MovementCompo.SetMovement(velocity * player.moveSpeed);
        HandleMovementEvent();
    }

    private void HandleMovementEvent() {
        if (player.InputReader.xMovement.sqrMagnitude < Mathf.Epsilon) {
            player.StateMachine.ChangeState(PlayerStateEnum.Idle);
        }
        else {
            movementDirection = player.InputReader.xMovement.normalized;
        }
    }
}
