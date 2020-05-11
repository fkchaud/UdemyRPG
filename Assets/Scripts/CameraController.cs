using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    private Transform target = null;

    [SerializeField]
    private Tilemap tilemap = null;

    private Bounds bounds;

    private void Awake()
    {
        if (tilemap == null)
            Debug.LogError($"{this.GetType().Name} object has not set targetSceneName variable.", this);

        float halfCameraHeight = Camera.main.orthographicSize;
        float halfCameraWidth = halfCameraHeight * Camera.main.aspect;

        bounds.min.x = tilemap.localBounds.min.x + halfCameraWidth;
        bounds.min.y = tilemap.localBounds.min.y + halfCameraHeight;
        bounds.max.x = tilemap.localBounds.max.x - halfCameraWidth;
        bounds.max.y = tilemap.localBounds.max.y - halfCameraHeight;
    }

    void Start()
    {
        target = PlayerController.Instance.transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, bounds.min.x, bounds.max.x),
            Mathf.Clamp(target.position.y, bounds.min.y, bounds.max.y),
            transform.position.z
        );
    }
}
