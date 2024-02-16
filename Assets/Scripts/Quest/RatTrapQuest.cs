using System;
using UnityEngine;

public class RatTrapQuest : MonoBehaviour
{
    [SerializeField] float maxDistance = 2f;
    [SerializeField] GameObject interactionIndicator;

    public static int countRatTrap;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _ratClip;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, maxDistance) && hit.collider.gameObject.CompareTag("RatTrap"))
        {
            
            interactionIndicator.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                _audioSource.PlayOneShot(_ratClip);
                Debug.Log("Rat");
                hit.collider.enabled = false;
                Count();

            }
        }else
            interactionIndicator.SetActive(false);
    }

    public static int Count()
    {
        if (QuestManager.LoadBool(QuestManager.boolEndKeyRatTrap))
        {
            countRatTrap = 0;
        }
        else
        {
            countRatTrap++;
        }
        return countRatTrap;
    }
}
