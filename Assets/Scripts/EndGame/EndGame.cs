using System;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private bool _End = false;

    void Update()
    {
        Debug.Log(IsPlayerInTrigger());
        if (Input.GetKeyDown(KeyCode.K) && IsPlayerInTrigger())
        {
            Debug.Log("End");
            Application.Quit();
        }
    }
    
    bool IsPlayerInTrigger()
    {
        if (_End)
        {
            return true;
        }
        return false; 
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            _End = true;
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _End = false;
        }
    }
}
