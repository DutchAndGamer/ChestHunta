using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Sound : MonoBehaviour 
{
    private Item_Master itemMaster;

    [Header("Volume")]
    public float defaultVolume;

    [Header("Audio Clips")]
    public AudioClip throwSound;
    public AudioClip pickupSound;

    void OnEnable () 
	{
        SetInitialReferences();
        itemMaster.EventObjectThrow += PlayThrowSound;
        itemMaster.EventObjectPickup += PlayPickupSound;
    }
	
	void OnDisable () 
	{
        itemMaster.EventObjectThrow -= PlayThrowSound;
        itemMaster.EventObjectPickup -= PlayPickupSound;
    }
	
	void SetInitialReferences () 
	{
        itemMaster = GetComponent<Item_Master>();
    }

    void PlayThrowSound()
    {
        if(throwSound != null)
        {
            AudioSource.PlayClipAtPoint(throwSound, transform.position, defaultVolume);
        }
    }

    void PlayPickupSound()
    {
        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position, defaultVolume);
        }
    }
}
