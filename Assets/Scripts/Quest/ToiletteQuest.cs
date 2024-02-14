using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToiletteQuest : MonoBehaviour
{
    public static int countToilette;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Toilette"))
        {
            Count();
        }
    }
    
    public static int Count()
    {
        countToilette = 1;
        return countToilette;
    }
}
