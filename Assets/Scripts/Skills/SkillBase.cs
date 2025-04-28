using UnityEngine;

public class SkillBase : ISkill
{
    public float cooldown;
    public virtual bool Use() {  return true; }
}
