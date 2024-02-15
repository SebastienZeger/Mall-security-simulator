using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoresQuest : MonoBehaviour
{
    [SerializeField] float maxDistance = 2f;
    [SerializeField] GameObject interactionIndicator;
    
    [SerializeField] private AudioClip _chainDoor;
    
    private AudioSource _audioSource;
    
    public static int countStore;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, maxDistance) && hit.collider.gameObject.CompareTag("DoorStore"))
        {
            
            interactionIndicator.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("DoorClosed");
                _audioSource.PlayOneShot(_chainDoor);
                hit.collider.enabled = false;
                Count();

            }
        }else
            interactionIndicator.SetActive(false);
    }

    public static int Count()
    {
        if (QuestManager.LoadBool(QuestManager.boolEndKeyStore))
        {
            countStore = 0;
        }
        else
        {
            countStore++;
        }
        
        return countStore;
    }
}
