using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    public Transform playerLocation;

    public static GameService Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

}
