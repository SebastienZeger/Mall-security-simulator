using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class InteractionDoor : MonoBehaviour
{
    [SerializeField] float maxDistance = 2f;
    [SerializeField] GameObject interactionIndicator;
    [SerializeField]  AudioClip _doorOpenClip;
    
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, maxDistance) && hit.collider.gameObject.CompareTag("Door"))
        {
            interactionIndicator.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                _audioSource.PlayOneShot(_doorOpenClip);
                OpenDoor();
            }
        }else
            interactionIndicator.SetActive(false);
    }

    void OpenDoor()
    {
        
        
        
    }
}
