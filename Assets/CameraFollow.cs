using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset; // Use this for a delay effect along z or other axes

    void Start()
    {
        // Optionally, set an initial offset based on the starting positions
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate() // Use LateUpdate for camera updates
    {
        // Target position considering the offset
        Vector3 targetPosition = playerTransform.position + offset;

        // Smoothly interpolate between the current position and the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
