using UnityEngine;

public class WeaponAxe : Weapon
{
    public WeaponAxe(WeaponData data)
    {
        this.data = data;
    }

    public override void Use()
    {
        Debug.Log($"Axe attacking with range{data.Range}"); ;
    }

    public override void Render()
    {

    }
}
