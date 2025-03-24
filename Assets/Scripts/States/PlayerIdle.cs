using UnityEngine;

public class PlayerIdle : PlayerState
{
    public override void Enter()
    {
        // play animation 
        Debug.Log("Enter Idle");
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        Debug.Log("Exit Idle");
    }
}
