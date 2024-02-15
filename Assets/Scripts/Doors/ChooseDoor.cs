using UnityEngine;

public class ChooseDoor : MonoBehaviour
{
    [SerializeField] int correctDoor = 2;
    [SerializeField] GameObject TpPos;

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