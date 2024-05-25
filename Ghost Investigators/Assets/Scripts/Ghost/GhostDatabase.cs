using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGhostDatabase",menuName = "Database/NewGhostDatabase")]
public class GhostDatabase : ScriptableObject
{
    public List<GhostTrait> ghostTraits;

    public GhostTrait GetGhostTrait(GhostType ghostType) =>  ghostTraits.Find(ghostrait => ghostrait.ghostType == ghostType);
    public GhostTrait GetRandomGhostTrait()
    {
        int random = Random.Range(0, 3);
        return ghostTraits[random];
    }

}


[System.Serializable]
public struct Evidence
{
    public EvidenceType evidenceType;
    [Range(0,100)]
    public float probablityToReveal;
}

public enum EvidenceType
{
    EmfReader,
    FingerPrints
}


public struct GhostModelData
{
    public Mesh ghostMesh;
   
}

public struct GhostAnimation
{
    
}
