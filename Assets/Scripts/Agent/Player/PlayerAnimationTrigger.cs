using  UnityEngine;

public  class PlayerAnimationtrigger : MonoBehaviour  {
    private Player player;

    private void Awake() {
        player = GetComponent<Player>();
    }

    public void AnimationEnd()  {
        player.StateMachine.CurrentState.AnimationFinishTrigger();
    }
}