using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    [SerializeField] private GameObject _torchLight;
    [SerializeField] private AudioClip _lightClip;
    
    private AudioSource _audioSource;

    private bool ON = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !ON)
        {
            _torchLight.SetActive(true);
            _audioSource.PlayOneShot(_lightClip);
            ON = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && ON)
        {
            _torchLight.SetActive(false);
            _audioSource.PlayOneShot(_lightClip);
            ON = false;
        }
    }
}
