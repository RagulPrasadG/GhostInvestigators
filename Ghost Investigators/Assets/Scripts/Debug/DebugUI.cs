using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugUI : MonoBehaviour
{
    #region Debug
    [Header("DEBUG")]
    [SerializeField] Button spawnGhostButton;
    [SerializeField] TMP_Text DebugGhostType;
    [SerializeField] GhostType ghostType;

    #endregion
    [Space(20)]
    [SerializeField] Transform spawnPoint;
    [SerializeField] GhostView ghostViewPrefab;
    [SerializeField] GhostDatabase ghostDatabase;

    private GhostController ghostController;

    public void OnClickSpawn()
    {
        GhostTrait ghostTrait = ghostDatabase.GetGhostTrait(ghostType);
        GhostView ghostViewInstance = Object.Instantiate(ghostViewPrefab, spawnPoint.transform.position, Quaternion.identity);
        switch (ghostType)
        {
            case GhostType.Revenant:
                
                ghostController = new Revenant(ghostViewInstance);
                break;
        }

        DebugGhostType.text = $"GhostType: {ghostTrait.name}";
        //SetRandomGhostModel()

    }
}
