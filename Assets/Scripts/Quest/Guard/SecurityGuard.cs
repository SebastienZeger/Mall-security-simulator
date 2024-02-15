using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SecurityGuard : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 2;
    private int index = 0;

    private void Update()
    {
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position,destination,speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            if (index < waypoints.Count - 1)
            {
                index++;
                
            }else if (index == waypoints.Count - 1)
            {
                enabled = false;
            }
        }
    }
}
