using UnityEngine;

public class PlayerWalk : PlayerState
{
    public override void Enter()
    {
        // play animation N
        Debug.Log("Enter Walk");
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        Debug.Log("Exit Walk");
    }
}
