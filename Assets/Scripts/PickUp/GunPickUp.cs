using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour, ILootable
{
    public WeaponControl gun;

    public void OnEndLook()
    {
        Debug.Log("Stopped looking at " + gun.gameObject.name);    
    }

    public void OnInteract()
    {
        WeaponControl.instance.PickUpGun(gun);
    }

    public void OnStartLook()
    {
        Debug.Log("Started looking at " + gun.gameObject.name);
    }
}
