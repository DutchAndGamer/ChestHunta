﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Master : MonoBehaviour 
{
    public Transform myTarget;
    public bool isOnRoute;
    public bool isNavPaused;

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventEnemyDie;
    public event GeneralEventHandler EventEnemyWalking;
    public event GeneralEventHandler EventEnemyReachedNavTarget;
    public event GeneralEventHandler EventEnemyAttack;
    public event GeneralEventHandler EventEnemyLostTarget;
    public event GeneralEventHandler EventEnemyHealthLow;
    public event GeneralEventHandler EventEnemyHealthRecovered;

    public delegate void HealthEventHandler(int health);
    public event HealthEventHandler EventEnemyDeductHealth;
    public event HealthEventHandler EventEnemyIncreaseHealth;

    public delegate void NavTargetEventHandler(Transform targetTransform);
    public event NavTargetEventHandler EventEnemySetNavTarget;

    public void CallEventEnemyDeductHealth(int health)
    {
        if(EventEnemyDeductHealth != null)
        {
            EventEnemyDeductHealth(health);
        }
    }

    public void CallEventEnemyIncreaseHealth(int health)
    {
        if (EventEnemyIncreaseHealth != null)
        {
            EventEnemyIncreaseHealth(health);
        }
    }

    public void CallEventEnemySetNavTarget(Transform targTransform)
    {
        if(EventEnemySetNavTarget != null)
        {
            EventEnemySetNavTarget(targTransform);
        }

        myTarget = targTransform;
    }

    public void CallEventEnemyDie()
    {
        if(EventEnemyDie != null)
        {
            EventEnemyDie();
        }
    }

    public void CallEventEnemyWalking()
    {
        if (EventEnemyWalking != null)
        {
            EventEnemyWalking();
        }
    }

    public void CallEventEventEnemyReachedNavTarget()
    {
        if (EventEnemyReachedNavTarget != null)
        {
            EventEnemyReachedNavTarget();
        }
    }

    public void CallEventEventEnemyAttack()
    {
        if (EventEnemyAttack != null)
        {
            EventEnemyAttack();
        }
    }

    public void CallEventEventEnemyLostTarget()
    {
        if (EventEnemyLostTarget != null)
        {
            EventEnemyLostTarget();
        }

        myTarget = null;
    }

    public void CallEventEnemyHealthLow()
    {
        if (EventEnemyHealthLow != null)
        {
            EventEnemyHealthLow();
        }
    }

    public void CallEventEnemyHealthRecovered()
    {
        if (EventEnemyHealthRecovered != null)
        {
            EventEnemyHealthRecovered();
        }
    }
}
