using UnityEngine;

public class IdleState : IState
{
    public void Enter() => Debug.Log("Entering Idle State");
    public void Execute() => Debug.Log("Idling...");
    public void Exit() => Debug.Log("Exiting Idle State");
}

public class PatrolState : IState
{
    public void Enter() => Debug.Log("Entering Patrol State");
    public void Execute() => Debug.Log("Patrolling...");
    public void Exit() => Debug.Log("Exiting Patrol State");
}

public class AttackState : IState
{
    public void Enter() => Debug.Log("Entering Attack State");
    public void Execute() => Debug.Log("Attacking...");
    public void Exit() => Debug.Log("Exiting Attack State");
}