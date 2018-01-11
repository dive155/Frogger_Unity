using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Detector : MonoBehaviour {

    public event Action ObstacleDetected;
    public event Action ObstacleGone;

    [SerializeField] private float range;

    private Vector3 endPoint;

    public bool Enabled { get; set; }

    private void Start()
    {
        Enabled = true;
    }

    private void FixedUpdate()
    {
        if (Enabled)
        {
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, range))
            {
                if (ObstacleDetected != null)
                {
                    ObstacleDetected();
                }
                endPoint = hit.point;
            }
            else
            {
                if (ObstacleGone != null)
                {
                    ObstacleGone();
                }
                endPoint = Vector3.zero;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (Enabled)
        {
            if (endPoint != Vector3.zero)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, endPoint);
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, transform.position + transform.forward.normalized * range);
            }
        }
    }
}
