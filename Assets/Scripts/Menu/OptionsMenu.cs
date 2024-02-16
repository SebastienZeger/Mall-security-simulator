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
    [SerializeField] Button _buttonQuit;
    
    private PlayerMovement _playerMovement;
    private PlayerCam _playerCam;
    private GameManager _gameManager;
    private InteractPad _interactPad;
    
    public bool _quitGame;
    
    public const string boolQuitGame = "quitGame";
    private static bool defaultsInitialized = false;

    private void Awake()
    {
        if (!defaultsInitialized)
        {
            InitializeDefaults();
            defaultsInitialized = true;
        }
    }

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerCam = FindObjectOfType<PlayerCam>();
        _gameManager = FindObjectOfType<GameManager>();
        _interactPad = FindObjectOfType<InteractPad>();
        
        if (LoadBool(boolQuitGame))
        {
            _buttonQuit.interactable = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _interactPad._canOpenOption)
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

    public void QuitGame()
    {
        _buttonQuit.interactable = false;
        _gameManager._test = true;
        SaveBool(boolQuitGame, true);
        _optionPanel.SetActive(false);
    }
    public static void SaveBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key,value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static bool LoadBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1;
    }
    
    public static void InitializeDefaults()
    {
        
        PlayerPrefs.SetInt(boolQuitGame, 0);
        PlayerPrefs.Save();
    }
}
