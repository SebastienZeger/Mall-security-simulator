using System;
using UnityEngine;

public class ChooseDoor : MonoBehaviour
{
    [SerializeField] int correctDoor = 2;
    [SerializeField] GameObject TpPos;
    
    [SerializeField] AudioClip _badDoorClip;
    [SerializeField] AudioSource _audioSource;

    public void Interact(int chosenDoor)
    {
        if (chosenDoor == correctDoor)
        {
            
            Debug.Log("Vous avez choisi la bonne porte!");
        }
        else
        {
            _audioSource.PlayOneShot(_badDoorClip);
            Debug.Log("Mauvais choix! Téléportation au début...");
            TeleportPlayer();
        }
    }
    
    void TeleportPlayer()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = TpPos.transform.position;

    }
}