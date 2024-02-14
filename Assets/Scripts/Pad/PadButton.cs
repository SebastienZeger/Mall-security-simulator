using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadButton : MonoBehaviour
{
    [SerializeField] private int num_Button = 1;
    public static int numbt = 12;

    public void SetNumberButton()
    {
        numbt = num_Button;
        Debug.Log(numbt);
    }
}
