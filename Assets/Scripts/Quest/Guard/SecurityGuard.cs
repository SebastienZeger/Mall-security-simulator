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
    private Animator animator;

    private SecurityGuardQuest _securityGuardQuest;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _securityGuardQuest = FindObjectOfType<SecurityGuardQuest>();
    }

    private void Update()
    {
        if (_securityGuardQuest._canMove)
        {
            Vector3 destination = waypoints[index].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position,destination,speed * Time.deltaTime);
            animator.SetBool("isMoving",true);
            transform.position = newPos;

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0.05)
            {
                if (index < waypoints.Count - 1)
                {
                    index++;
                
                }else if (index == waypoints.Count - 1)
                {
                    animator.SetBool("isMoving",false);
                    enabled = false;
                }
            }
        }
    }
}
