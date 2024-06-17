using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [Header("Ground Check")]
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private Vector3 offset;
    [SerializeField] private LayerMask groundLayer;
    private Player agent;

    private Vector2 velocity;
    public Vector2 Velocity => velocity;
    public bool IsGround => IsGroundMethod();

    public void Initialize(Agent agent) {
        this.agent = agent as Player;
    }

    private void FixedUpdate() {
        Move();
    }

    public void SetMovement(Vector3 movement) {
        velocity = movement;
    }

    public void StopImmediately() {
        velocity = Vector2.zero;
    }

    private void Move() {
        agent.RigidCompo.velocity = new Vector2(velocity.x, agent.RigidCompo.velocity.y);
    }

    private bool IsGroundMethod() {
        if (Physics2D.OverlapBox(transform.position + offset, groundCheckSize, 0, groundLayer)) {
            return true;
        }
        else {
            return false;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + offset, groundCheckSize);
    }
}
