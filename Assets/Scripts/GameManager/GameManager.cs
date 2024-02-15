using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timerDuration = 10f;
    private float timer;
    
    [SerializeField] List<string> resetMessages;
    [SerializeField] TextMeshProUGUI randomMessageText;
    [SerializeField] private float timeMessage;
    public GameObject _videoScreen;

    private bool _reset = false;
    private bool _sendMessage = true;
    private bool _ticTac = true;

    private VideoManager _videoManager;
    private PlayerMovement _playerMovement;
    private PlayerCam _playerCam;
    
    [SerializeField] AudioSource _audioSource;

    [SerializeField] private AudioClip[] _audioClipsListGlitchClips;
    [SerializeField] private AudioClip[] _audioClipsListVideoClips;

    void Start()
    {
        timer = timerDuration;
        _videoManager = FindObjectOfType<VideoManager>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerCam = FindObjectOfType<PlayerCam>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        
        if (IsGuardInteracted() || IsObjectiveCompleted())
        {
            ResetLevel();
        }else if (timer <= 0f && _ticTac)
        {
            ResetLevel();
            
        }
        
    }

    bool IsGuardInteracted()
    {
        if (BadGuard.sucess)
        {
            return true;
        }
        return false;
    }

    bool IsObjectiveCompleted()
    {
        if (StoresQuest.countStore == 5 || RatTrapQuest.countRatTrap == 2 || ToiletteQuest.countToilette == 1)
        {
            return true;
        } 
        return false;
    }

    void ResetLevel()
    {
        if (_sendMessage)
        {
            int indexAleatoire = Random.Range(0, _audioClipsListGlitchClips.Length);
            _audioSource.clip = _audioClipsListGlitchClips[indexAleatoire];
            _audioSource.PlayOneShot(_audioSource.clip);
            _playerCam.enabled = false;
            _playerMovement.enabled = false;
            StartCoroutine(ShowRandomResetMessage());
        }
        
        if (_reset)
        {
            _ticTac = false;
            int indexAleatoire = Random.Range(0, _audioClipsListVideoClips.Length);
            _audioSource.clip = _audioClipsListVideoClips[indexAleatoire];
            _audioSource.PlayOneShot(_audioSource.clip);
            _videoScreen.SetActive(true);
            _videoManager.PlayRandomVideo();
            StopCoroutine(ShowRandomResetMessage());
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            ResetScore();
            _reset = false;
        }
    }

    void ResetScore()
    {
        StoresQuest.countStore = 0;
        RatTrapQuest.countRatTrap = 0;
        ToiletteQuest.countToilette = 0;
        SecurityGuardQuest.countGuard = 0;
        BadGuard.sucess = false;
        _sendMessage = true;
    }
    
    IEnumerator ShowRandomResetMessage()
    {
        while (_sendMessage)
        {
            int randomIndex = Random.Range(0, resetMessages.Count);
            string randomMessage = resetMessages[randomIndex];
            randomMessageText.text = randomMessage;
            _sendMessage = false;
            yield return new WaitForSeconds(timeMessage);
            randomMessageText.text = "";
            _reset = true;
        }
    }
}