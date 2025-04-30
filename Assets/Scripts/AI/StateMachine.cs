using UnityEngine;

using System.Collections.Generic;

public interface IState
{
    void Enter();
    void Execute();
    void Exit();
}

public class StateMachine : MonoBehaviour
{
    public IState[] states;
    private IState currentState;

    public void ChangeState(IState newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;

        if (currentState != null)
            currentState.Enter();
    }

    public void Update()
    {
        if (currentState != null)
            currentState.Execute();
    }
}