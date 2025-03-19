using UnityEngine;

public abstract class Weapon
{
    public string Name;
    public float Damage;
    public float Range;
    public float Cooldown;

    public abstract void Use();
    public abstract void Render();

    public float GetDamage()
    {
        return Damage;
    }
}
