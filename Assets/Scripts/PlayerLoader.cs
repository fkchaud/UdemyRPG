using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject characterPrefab;

    void Awake()
    {
        if (PlayerController.Instance == null)
            Instantiate(characterPrefab);
    }
}
