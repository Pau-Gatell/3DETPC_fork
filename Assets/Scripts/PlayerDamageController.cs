using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    private Weapon weaponPrimary;

    private int weaponUse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weaponPrimary = new WeaponAxe();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponPrimary = new WeaponAxe();
            Debug.Log("Primary weapon changed to [AXE]");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponPrimary = new WeaponGun();
            Debug.Log("Primary weapon changed to [GUN]");
        }

        if (Input.GetMouseButtonDown(0))
            weaponPrimary.Use();
    }
}
