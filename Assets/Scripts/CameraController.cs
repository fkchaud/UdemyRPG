using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    private Transform target = null;

    [SerializeField]
    private Tilemap tilemap = null;

    private float minLimitX = 0;
    private float minLimitY = 0;
    private float maxLimitX = 0;
    private float maxLimitY = 0;

    private void Awake()
    {
        if (tilemap == null)
            Debug.LogError($"{this.GetType().Name} object has not set targetSceneName variable.", this);

        float halfCameraHeight = Camera.main.orthographicSize;
        float halfCameraWidth = halfCameraHeight * Camera.main.aspect;

        minLimitX = tilemap.localBounds.min.x + halfCameraWidth;
        minLimitY = tilemap.localBounds.min.y + halfCameraHeight;
        maxLimitX = tilemap.localBounds.max.x - halfCameraWidth;
        maxLimitY = tilemap.localBounds.max.y - halfCameraHeight;
    }

    void Start()
    {
        target = PlayerController.Instance.transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, minLimitX, maxLimitX),
            Mathf.Clamp(target.position.y, minLimitY, maxLimitY),
            transform.position.z
        );
    }
}
