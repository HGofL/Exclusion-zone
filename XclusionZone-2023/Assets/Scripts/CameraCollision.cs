using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;

    private Transform pivot;
    private float distance;

    private void Start()
{
    // Assuming the camera is a child of another GameObject (the pivot)
    // Make sure the parent (pivot) is assigned in the Unity Editor
    pivot = transform.parent;

    if (pivot == null)
    {
        Debug.LogError("CameraCollision script requires a parent (pivot) GameObject.");
        return;
    }

    distance = Vector3.Distance(transform.position, pivot.position);
}

    private void Update()
    {
        RaycastHit hit;
        Vector3 direction = transform.position - pivot.position;

        if (Physics.Raycast(pivot.position, direction, out hit, distance))
        {
            float targetDistance = hit.distance - minDistance;

            if (targetDistance < 0)
                targetDistance = 0;

            distance = Mathf.Lerp(distance, targetDistance + minDistance, Time.deltaTime * smooth);
        }
        else
        {
            distance = Mathf.Lerp(distance, maxDistance, Time.deltaTime * smooth);
        }

        transform.localPosition = new Vector3(0, 0, -distance);
    }
}
