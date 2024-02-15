using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject _toiletteLight;
    [SerializeField] Toggle toggle;
    [SerializeField] TextMeshProUGUI _textSecret;

    [SerializeField] string[] TextSecretSettings;
    [SerializeField] GameObject _optionPanel;
    
    private PlayerMovement _playerMovement;
    private PlayerCam _playerCam;

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerCam = FindObjectOfType<PlayerCam>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _optionPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _playerCam.enabled = false;
            _playerMovement.enabled = false;
        }
    }

    public void ToggleObjectActivation()
    {
        if (toggle.isOn)
        {
            _toiletteLight.SetActive(true);
        }
        else if (!toggle.isOn)
        {
            _toiletteLight.SetActive(false);
        }
    }

    public void ChangeSecretSettings()
    {
        int indexAleatoire = Random.Range(0, TextSecretSettings.Length);
        string TextRandom = TextSecretSettings[indexAleatoire];
        _textSecret.text = TextRandom;
    }

    public void ExitOptionMenu()
    {
        _optionPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _playerCam.enabled = true;
        _playerMovement.enabled = true;
    }
    
}
