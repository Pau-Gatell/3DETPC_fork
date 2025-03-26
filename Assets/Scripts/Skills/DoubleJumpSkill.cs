using UnityEngine;

public class DoubleJumpSkill : SkillBase
{
    public bool isOnCooldown = false;
    public float jumpValue = 0;

    public override bool Use()
    {
        base.Use();
        bool space = Input.GetButtonDown("Jump");
        Debug.Log("Double Jumping");

        if (!PlayerController.Instance.IsGrounded())
        {
            if (space && !isOnCooldown)
            {
                // Double Jumping
                jumpValue = PlayerController.Instance.model.jumpGravity;
                isOnCooldown = true;
                return true;
            }
        }

        if(PlayerController.Instance.IsGrounded())
        {
            isOnCooldown = false;
        }

        return false;
    }
}
