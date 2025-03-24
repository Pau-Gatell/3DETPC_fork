using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerState", order = 1)]
public class PlayerState : ScriptableObject
{
    public PlayerStateMachine.StateType type;
    public virtual void Enter() { }
    public virtual void Tick() { }
    public virtual void Exit() { }
}
