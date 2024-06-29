using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanAttackState : PlayerState
{
    public PlayerCanAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.InputReader.AttackEvent += AttackHandle;
    }

    private void AttackHandle()
    {
        if (WeaponManager.Instance.CurrentEquippedWeapon  == null) {
            if (player.MovementCompo.IsGround == false) {
                return;
            }
        }
        player.StateMachine.ChangeState(PlayerStateEnum.Attack);
    }

    public override void Exit()
    {
        base.Exit();
        player.InputReader.AttackEvent -= AttackHandle;
    }
}
