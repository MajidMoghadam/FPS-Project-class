using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public Gun gun;                // current gun reference
    private bool isHoldingShoot;   // true while left mouse is held
    public Transform gunHolder;    // drag GunHolder here in Inspector

    void OnShoot()                 // called when Shoot action starts
    {
        isHoldingShoot = true;
    }

    void OnShootRelease()          // called when Shoot action ends
    {
        isHoldingShoot = false;
    }

    void OnReload()                // called when Reload action triggers
    {
        if (gun != null)
            gun.TryReload();       // reload current gun
    }

    void Update()
    {
        if (isHoldingShoot && gun != null)
            gun.Shoot();           // fire continuously while held
    }
}
