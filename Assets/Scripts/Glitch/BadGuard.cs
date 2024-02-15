using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuard : MonoBehaviour
{

    public static bool sucess;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Sucess();
        }
    }

    public static bool Sucess()
    {
        sucess = true;
        return sucess;
    }
}
