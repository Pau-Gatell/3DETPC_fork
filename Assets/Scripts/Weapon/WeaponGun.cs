using UnityEngine;

public class WeaponGun : Weapon
{
    public WeaponGun(WeaponData data)
    {
        this.data = data;
    }

    public override void Use()
    {
        Debug.Log($"Gun attacking with range{data.Range}");
    }

    public override void Render()
    {

    }
}
