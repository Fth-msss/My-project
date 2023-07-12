using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //things like speed, held item here
    //also has events 
    Pickup heldPickup;

    float jumppower;
    float rotationspeed;
    float bounciness;

    public Pickup HeldPickup 
    {
     
        get { return heldPickup; }

        set { heldPickup = value; PowerupchangeEvent?.Invoke(heldPickup); }

    }

    public delegate void PowerupChangeEventHandler(Pickup pickup);
    public static event PowerupChangeEventHandler PowerupchangeEvent;
  
}
