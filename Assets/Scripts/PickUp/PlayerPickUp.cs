using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour, ILootable
{
    public void OnEndLook()
    {
        Debug.Log("Stopped looking at");
    }

    public void OnInteract()
    {
        Debug.Log("Picked Up");
    }

    public void OnStartLook()
    {
        Debug.Log("Started looking at");
    }

}
