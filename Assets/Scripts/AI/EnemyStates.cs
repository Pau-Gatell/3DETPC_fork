using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "EnemyState/IdleState", order = 1)]
public class IdleState : IState
{
    public override void Enter() => Debug.Log("Entering Idle State");
    public override void Execute() => Debug.Log("Idling...");
    public override void Exit() => Debug.Log("Exiting Idle State");
}

[CreateAssetMenu(fileName = "PatrolState", menuName = "EnemyState/PatrolState", order = 2)]
public class PatrolState : IState
{
    public override void Enter() => Debug.Log("Entering Patrol State");
    public override void Execute() => Debug.Log("Patrolling...");
    public override void Exit() => Debug.Log("Exiting Patrol State");
}

[CreateAssetMenu(fileName = "AttackState", menuName = "EnemyState/AttackState", order = 3)]
public class AttackState : IState
{
    public override void Enter() => Debug.Log("Entering Attack State");
    public override void Execute() => Debug.Log("Attacking...");
    public override void Exit() => Debug.Log("Exiting Attack State");
}