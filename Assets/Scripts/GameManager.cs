using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timerDuration = 120f;
    private float timer;
    
    [SerializeField] List<string> resetMessages;
    [SerializeField] TextMeshProUGUI randomMessageText;
    [SerializeField] private float timeMessage;

    private bool _reset = false;
    private bool _sendMessage = true;

    void Start()
    {
        timer = timerDuration;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0f || IsGuardInteracted() || IsObjectiveCompleted())
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
            StartCoroutine(ShowRandomResetMessage());
        }
        
        if (_reset)
        {
            StopCoroutine(ShowRandomResetMessage());
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            ResetScore();
            _reset = false;
        }
    }

    void ResetScore()
    {
        StoresQuest.countStore = 0;
        RatTrapQuest.countRatTrap = 0;
        ToiletteQuest.countToilette = 0;
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