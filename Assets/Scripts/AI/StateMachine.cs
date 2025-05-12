using UnityEngine;

using System.Collections.Generic;
using System;

[Serializable]
public abstract class IState : ScriptableObject
{
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}

public class StateMachine : MonoBehaviour
{
    [SerializeField]public IState[] states;
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