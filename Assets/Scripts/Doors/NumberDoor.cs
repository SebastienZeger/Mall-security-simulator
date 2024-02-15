using UnityEngine;

public class NumberDoor : MonoBehaviour
{
    [SerializeField] int doorID;
    [SerializeField] ChooseDoor ChooseDoor;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChooseDoor.Interact(doorID);
        }
    }
}

