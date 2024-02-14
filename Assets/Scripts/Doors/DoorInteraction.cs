using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public int doorID;
    public ChooseDoor ChooseDoor;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChooseDoor.Interact(doorID);
        }
    }
}

