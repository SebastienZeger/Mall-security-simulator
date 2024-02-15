using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    [SerializeField] private GameObject _torchLight;

    private bool ON = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !ON)
        {
            _torchLight.SetActive(true);
            ON = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && ON)
        {
            _torchLight.SetActive(false);
            ON = false;
        }
    }
}
