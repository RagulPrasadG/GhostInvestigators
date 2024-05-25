using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGhostTrait",menuName = "Traits/NewGhostTrait")]
public class GhostTrait : ScriptableObject
{
    public GhostType ghostType;
    public string ghostName;
    public float roamingRadius;
    public float LOSSpeed;
    public float patrolSpeed;
    public float modelFlickerTime;
    public float maxFlickerTime;
    [Range(0, 360)]
    public float fieldOfView;
    [Range(0,100)]
    public float huntingSanity;
    [Range(0, 100)]
    public float ghosteventSanity;
    [Range(0, 100)]
    public float ghostInteractionSanity;
    public float activity;
    public float eventDuration;

    [Header("Interaction")]
    [Space(20)]
    public float interactionRate;
    public float throwforce;
    public float throwCoolDown;

    [Header("Evidences")]
    [Space(20)]
    public Evidence[] evidences;
}

public enum GhostType
{
    Revenant,
    Jinn,
    Phantom
}
