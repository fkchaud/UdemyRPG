using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target = null;

    void Start()
    {
        //if (target == null)
        //    Debug.LogError($"{this.GetType().Name} object has not set target variable.", this);
        target = PlayerController.Instance.transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
