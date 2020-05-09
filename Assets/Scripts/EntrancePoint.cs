using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrancePoint : MonoBehaviour
{
    private string transitionPointName = "";

    private void Start()
    {
        transitionPointName = GetComponentInParent<AreaExit>().TransitionPointName;

        if (PlayerController.Instance.LastTransitionPointName == transitionPointName)
            PlayerController.Instance.transform.position = transform.position;
    }
}
