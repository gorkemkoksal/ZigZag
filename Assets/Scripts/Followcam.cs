using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followcam : MonoBehaviour
{
    [SerializeField] Transform target;
    private Vector3 offset;
    void Awake()
    {
        offset = transform.position - target.transform.position;
    }
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
