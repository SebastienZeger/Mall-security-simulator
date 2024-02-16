using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPad : MonoBehaviour
{
    [SerializeField] float maxDistance = 2f;
    [SerializeField] GameObject interactionIndicator;
    [SerializeField] GameObject pinPad;

    private PlayerMovement _playerMovement;
    private PlayerCam _playerCam;
    private bool interact;

    public bool _canOpenOption = true;

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerCam = FindObjectOfType<PlayerCam>();
        _canOpenOption = true;
    }

    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, maxDistance) && hit.collider.gameObject.CompareTag("PinPadDoor"))
        {
            if (!interact)
            {
                interactionIndicator.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _canOpenOption = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pinPad.SetActive(true);
                interactionIndicator.SetActive(false);
                _playerCam.enabled = false;
                _playerMovement.enabled = false;
                interact = true;
            }
        }else
            interactionIndicator.SetActive(false);
    }
    
    public void GoodPin()
    {
        _canOpenOption = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pinPad.SetActive(false);
        _playerCam.enabled = true;
        _playerMovement.enabled = true;
        
    }

    public void ExitPinPad()
    {
        _canOpenOption = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pinPad.SetActive(false);
        _playerCam.enabled = true;
        _playerMovement.enabled = true;
    }
}
