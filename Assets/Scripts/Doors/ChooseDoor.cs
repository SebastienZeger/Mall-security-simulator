using UnityEngine;

public class ChooseDoor : MonoBehaviour
{
    public int correctDoor = 2;
    public GameObject TpPos;
    
    public void Interact(int chosenDoor)
    {
        if (chosenDoor == correctDoor)
        {
            Debug.Log("Vous avez choisi la bonne porte!");
        }
        else
        {
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