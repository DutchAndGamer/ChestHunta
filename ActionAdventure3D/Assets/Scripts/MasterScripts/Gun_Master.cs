using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Master : MonoBehaviour 
{
    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventPlayerInput;
    public event GeneralEventHandler EventGunNotUsable;
    public event GeneralEventHandler EventRequestReload;
    public event GeneralEventHandler EventRequestGunReset;
    public event GeneralEventHandler EventToggleBurstFire;

    public delegate void GunHitEventHandler(Vector3 hitPosition, Transform hitTransform);
    public event GunHitEventHandler EventShotDefault;
    public event GunHitEventHandler EventShotTarget;

    public delegate void GunAmmoEventHandler(int currentAmmo, int carriedAmmo);
    public event GunAmmoEventHandler EventAmmoChanged;

    public delegate void GunCrosshairEventHandler(float speed);
    public event GunCrosshairEventHandler EventSpeedCapture;

    public bool isGunLoaded;
    public bool isReloading;

    public void CallEventPlayerInput()
    {
        if(EventPlayerInput != null)
        {
            EventPlayerInput();
        }
    }

    public void CallEventGunNotUsable()
    {
        if (EventGunNotUsable != null)
        {
            EventGunNotUsable();
        }
    }

    public void CallEventRequestReload()
    {
        if (EventRequestReload != null)
        {
            EventRequestReload();
        }
    }

    public void CallEventRequestGunReset()
    {
        if(EventRequestGunReset != null)
        {
            EventRequestGunReset();
        }
    }

    public void CallEventToggleBurstFire()
    {
        if (EventToggleBurstFire != null)
        {
            EventToggleBurstFire();
        }
    }

    public void CallEventShotDefault(Vector3 hPos, Transform hTransform)
    {
        if(EventShotDefault != null)
        {
            EventShotDefault(hPos, hTransform);
        }
    }

    public void CallEventShotTarget(Vector3 hPos, Transform hTransform)
    {
        if (EventShotTarget != null)
        {
            EventShotTarget(hPos, hTransform);
        }
    }

    public void CallEventAmmoChanged(int curAmmo, int carAmmo)
    {
        if (EventAmmoChanged != null)
        {
            EventAmmoChanged(curAmmo, carAmmo);
        }
    }

    public void CallEventSpeedCapture(float spd)
    {
        if (EventSpeedCapture != null)
        {
            EventSpeedCapture(spd);
        }
    }
}
