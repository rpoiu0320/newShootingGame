using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] Gun gun;

    // List<Gun> gunList = new List<Gun>();

    public void Fire()
    {
        gun.Fire();
    }

    public void SwapWeapon()
    {

    }

    public void GetWeapon()
    {

    }
}
