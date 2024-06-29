using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        if (WeaponManager.Instance.CurrentEquippedWeapon == null) {
            base.Enter();
            player.MovementCompo.StopImmediately();
        }
        else {
            if (WeaponManager.Instance.CurrentEquippedWeapon is RangedWeapon) {
                WeaponManager.Instance.CurrentEquippedWeapon.anim.SetTrigger("Shoot");
                (WeaponManager.Instance.CurrentEquippedWeapon as RangedWeapon).Shoot();
            }
            else if (WeaponManager.Instance.CurrentEquippedWeapon is MeleeWeapon) {
                WeaponManager.Instance.CurrentEquippedWeapon.anim.SetTrigger("Attack");
                (WeaponManager.Instance.CurrentEquippedWeapon as MeleeWeapon).Attack();
            }
            player.StateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    public override void UpdateState()
    {
        if (endTriggerCalled) {
            player.StateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
