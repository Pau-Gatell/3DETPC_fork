using UnityEngine;

public class PlayerJump : PlayerState
{
    public override void Enter()
    {
        // play animation N
        Debug.Log("Enter Jump");
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        Debug.Log("Exit Jump");
    }
}
