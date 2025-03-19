using UnityEngine;

public abstract class Weapon
{
    public WeaponData data;

    public abstract void Use();
    public abstract void Render();

    public float GetDamage()
    {
        return data.Damage;
    }
}
