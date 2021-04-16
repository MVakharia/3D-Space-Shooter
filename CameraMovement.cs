using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float moveSpeed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

        transform.rotation = target.transform.rotation;
    }
}
