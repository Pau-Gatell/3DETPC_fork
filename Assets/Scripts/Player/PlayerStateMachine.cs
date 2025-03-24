using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public enum StateType
    {
        IDLE,
        WALK,
        JUMP
    }

    public PlayerState[] states;
    public PlayerState currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentState.Tick();
    }

    public void ChangeState(StateType type)
    {
        PlayerState state = GetTargetState(type);

        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }

    private PlayerState GetTargetState(StateType type)
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i].type == type)
                return states[i];
        }

        return null;
    }
}
