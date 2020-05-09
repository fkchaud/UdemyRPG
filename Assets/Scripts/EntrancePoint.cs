using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrancePoint : MonoBehaviour
{
    [SerializeField]
    private string transitionPointName = "";

    private void Start()
    {
        if (string.IsNullOrWhiteSpace(transitionPointName))
            Debug.LogError($"{this.GetType().Name} object has not set transitionPointName variable.", this);

        if (PlayerController.Instance.LastTransitionPointName == transitionPointName)
            PlayerController.Instance.transform.position = transform.position;
    }
}
