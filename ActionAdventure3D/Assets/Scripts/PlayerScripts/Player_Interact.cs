using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour 
{
    [Tooltip("What layer is being used for items?")]
    public LayerMask layerToDetect;
    [Tooltip("What transform will the ray be fired from?")]
    public Transform rayTransformPivot;
    [Tooltip("The editor input button that will be used for picking up items")]
    public string buttonPickup;

    private Transform interactable;
    private RaycastHit hit;
    private float detectRange = 3;
    private float detectRadius = 0.7f;
    private bool itemInRange;

    void Update()
    {
        CastRayForDetectingInteractable();
        CheckForInteraction();
    }

    void CastRayForDetectingInteractable()
    {
        if (Physics.SphereCast(rayTransformPivot.position, detectRadius, rayTransformPivot.forward, out hit, detectRange, layerToDetect))
        {
            interactable = hit.transform;
            itemInRange = true;
        }
        else
        {
            itemInRange = false;
        }
    }

    void CheckForInteraction()
    {
        if (Input.GetButtonDown(buttonPickup) && Time.timeScale > 0 && itemInRange && interactable.root.tag != GameManager_References._playerTag)
        {
            Debug.Log("Interaction");
            interactable.GetComponent<Chest_Master>().CallEventOpenChest();
        }
    }
}
