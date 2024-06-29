using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions, IUIActions
{
    #region Player 
    public event Action JumpEvent;
    public event Action AttackEvent;
    #endregion

    #region UI
    public event Action InvenEvent;
    #endregion

    private bool isDragging = false;

    private Controls _controls;
    public Controls GetControl()
    {
        return _controls;
    }

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
            _controls.Player.SetCallbacks(this);
            _controls.UI.SetCallbacks(this);
        }

        _controls.Player.Enable();
        _controls.UI.Enable();
    }

    public Vector2 xMovement;
    public void OnMovement(InputAction.CallbackContext context)
    {
        xMovement = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) {
            JumpEvent?.Invoke();
        }
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.performed) {
            InvenEvent?.Invoke();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(!EventSystem.current.IsPointerOverGameObject()) {  
            if (context.performed) {
                AttackEvent?.Invoke();
            }
	    }
    }
}
